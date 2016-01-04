using ACMA.Domain.Entities.RFID;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using serviceDomain = ACMA.CaptureAndFilteringDataService.FormatterService;
using ACMA.Application.Services;
using ACMA.Repository.Repository;
using ACMA.Domain.Entities.Commom;

namespace ACMA.CaptureAndFilteringDataService
{
    partial class CaptureAndFilteringDataService : ServiceBase
    {
        private TcpListener _tcpListener { get; set; }
        private TcpClient _clientForBrowser { get; set; }
        private NetworkStream _streamForBrowser { get; set; }
        private List<RawData> _rawDataList { get; set; }
        private Timer _timerIntervalToSendData { get; set; }
        public string _ipAddress { get; set; }
        public int _port { get; set; }
        private int _intervalSendDataDatabase { get; set; }
        private bool _existsSaveProcessInProgress { get; set; }

        public CaptureAndFilteringDataService()
        {
            InitializeComponent();
            LoadConfigurationValuesForAttributes();
        }

        private void LoadConfigurationValuesForAttributes()
        {
            using (var configurationRepository = new ConfigurationRepository())
            {
                Dictionary<string, string> attributesValues = configurationRepository.GetCaptureAndFilteringDataServiceConfigurations();
                this._ipAddress = attributesValues.Where(p => p.Key == ConfigurationKey.SERVER_IPADDRESS.ToString())
                                                                             .Select(p => p.Value)
                                                                             .Single();
                this._port = int.Parse(attributesValues.Where(p => p.Key == ConfigurationKey.PORT.ToString())
                                                                             .Select(p => p.Value)
                                                                             .Single());
                this._intervalSendDataDatabase = int.Parse(attributesValues.Where(p => p.Key == ConfigurationKey.INTERVAL_SEND_DATA_TO_DATABASE.ToString())
                                                             .Select(p => p.Value)
                                                             .Single());
            }
            //Cria o listenner na porta TCP
            _tcpListener = new TcpListener(IPAddress.Parse(_ipAddress), _port);
            _rawDataList = new List<RawData>();
            _existsSaveProcessInProgress = false;
        }

        protected override void OnStart(string[] args)
        {
            _tcpListener.Start();
            Console.WriteLine("Server has started...");

            //Laço de repetição para ficar escutando na porta TCP e criar thread para cada nova conexão
            while (true)
            {
                _clientForBrowser = _tcpListener.AcceptTcpClient();
                ThreadPool.QueueUserWorkItem(ThreadProc, _clientForBrowser);
                System.Threading.Thread.Sleep(1000);
            }
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }

        //Método principal da thread - Recebe dados provenientes de Leitores e envia para formatação
        private void ThreadProc(object obj)
        {
            var client = (TcpClient)obj;
            NetworkStream streamForRifidi = client.GetStream();
            StreamManager(streamForRifidi, client);
        }

        //Método gerenciador de Streams
        private void StreamManager(NetworkStream streamForRifidi, TcpClient client)
        {
            //Laço para ficar sempre esperando nova chegada de informações na porta TCP configurada
            while (true)
            {
                while (!streamForRifidi.DataAvailable) ;

                Byte[] bytes = new Byte[client.Available];
                streamForRifidi.Read(bytes, 0, bytes.Length);

                //Decodifica as mensagens recebidas do RFID 
                string incomingData = Encoding.UTF8.GetString(bytes);

                //Formata os dados recebidos
                using (var formatterService = new serviceDomain.FormatterService())
                {
                    lock (_rawDataList)
                    {
                        _rawDataList = formatterService.FormatIncomingData(_rawDataList, incomingData);
                    }
                    //Verifica se chegaram novas leituras de tags
                    if (_rawDataList.Count != 0)
                    {
                        //Verifica se envia agora dados para base ou seta o timer com o tmepo de envio
                        if (!_existsSaveProcessInProgress)
                        {
                            _existsSaveProcessInProgress = true;
                            var intervalToSendData = GetIntervalSendDataToDatabase();
                            SaveFormattedRawDataAsync(intervalToSendData);
                        }
                    }
                }
            }
        }

        //Busca o tempo de interval para envio dos dados da aplicação para o banco de dados na nuvem
        private int GetIntervalSendDataToDatabase()
        {
            using (var configurationRepository = new ConfigurationRepository())
            {
                var currentNetworkStatus = ConvertToNetworkBandwidthMonitorStatus(configurationRepository.GetConfigurationValue(ConfigurationKey.CURRENT_NETWORK_STATUS));
                var intervalToSend = int.Parse(configurationRepository.GetConfigurationValue(currentNetworkStatus));
                return intervalToSend;
            }
        }

        //Converte a string do status para a configuration key correta
        private ConfigurationKey ConvertToNetworkBandwidthMonitorStatus(string networkBandwidthMonitorStatus)
        {
            if (networkBandwidthMonitorStatus == "OK")
            {
                return ConfigurationKey.OK_NETWORK_MAX_USAGE_PERCENTUAL;
            }
            else if (networkBandwidthMonitorStatus == "WARNING")
            {
                return ConfigurationKey.WARNING_NETWORK_MAX_USAGE_PERCENTUAL;
            }
            else
            {
                return ConfigurationKey.CRITICAL_NETWORK_MAX_USAGE_PERCENTUAL;
            }
        }

        private async void SaveFormattedRawDataAsync(int intervalToSendData)
        {
            using (var activeAssetService = new ActiveAssetService())
            {
                //Vai salvar os itens lidos até então e limpar a lista para ficar agaurdando novas leituras para os proximos processamentos
                var rawDataListForSave = new List<RawData>();
                rawDataListForSave = _rawDataList.ToList();
                lock (_rawDataList)
                {
                    _rawDataList.Clear();
                }
                await Task.Delay(intervalToSendData);
                await Task.Run(() => activeAssetService.SaveFormattedRawData(rawDataListForSave));
                _existsSaveProcessInProgress = false;
            }
        }
    }
}
