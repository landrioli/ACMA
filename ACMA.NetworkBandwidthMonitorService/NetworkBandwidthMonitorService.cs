using ACMA.Domain.Entities.Commom;
using ACMA.Domain.Entities.NetworkBandwidth;
using ACMA.Repository.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using RepositoryDomain = ACMA.Repository.Repository;

namespace ACMA.NetworkBandwidthMonitorService
{
    partial class NetworkBandwidthMonitorService : ServiceBase
    {
        public NetworkInterface _networkInterface { get; set; }
        public long _totalBytesSend { get; set; }
        public long _totalBytesReceived { get; set; }
        public Queue<double> _valores { get; set; }
        public int _testSpeedQuantity { get; set; }
        public double _maxSpeedLink { get; set; }
        public double _maxThresholdSpeed { get; set; }
        public double _minThresholdSpeed { get; set; }
        public double _intervalTimerNetworkVerification { get; set; }
        public Timer _timerNetworkBandwidthMonitor { get; set; }
        public ConfigurationRepository _configurationRepository { get; set; }

        public NetworkBandwidthMonitorService()
        {
            InitializeComponent();
            LoadConfigurationValuesForAttributes();
        }

        protected override void OnStart(string[] args)
        {
            //Timmer para verificação da velocidade da internet
            _timerNetworkBandwidthMonitor = new Timer();
            _timerNetworkBandwidthMonitor.Elapsed += new ElapsedEventHandler(OnElapsedTimerNetworkBandwidthMonitor);
            _timerNetworkBandwidthMonitor.Interval = _intervalTimerNetworkVerification;
            _timerNetworkBandwidthMonitor.Enabled = true;
        }

        protected override void OnStop()
        {
            _timerNetworkBandwidthMonitor.Enabled = false;
        }

        private void OnElapsedTimerNetworkBandwidthMonitor(object sender, ElapsedEventArgs e)
        {
            CalculaEstimativaVelocidadeAtual();
        }

        public void CalculaEstimativaVelocidadeAtual()
        {
            double currentNetworkSpeed = 0;
            int accountedTests = 0;
            for (int i = 0; i < _testSpeedQuantity; i++)
            {
                //Pega estatisticas da interface atual
                IPv4InterfaceStatistics interfaceStatistic = _networkInterface.GetIPv4Statistics();

                //Velocidade bytes enviados = total de bytes enviado até esta interação - total de bytes enviados até ultima checkagem
                int bytesSentSpeed = (int)(interfaceStatistic.BytesSent - _totalBytesSend) / 1024;

                //Velocidade bytes recebidos = total de bytes recebidos até esta interação - total de bytes recebidos até ultima checkagem
                int bytesReceivedSpeed = (int)(interfaceStatistic.BytesReceived - _totalBytesReceived) / 1024;

                //Atualiza a quantidade de dados recebidos na iteração
                _totalBytesSend = interfaceStatistic.BytesSent;
                _totalBytesReceived = interfaceStatistic.BytesReceived;

                //Verifica limiares que fujam da normalidade - Picos que acontecem por acaso
                if (bytesReceivedSpeed < _maxThresholdSpeed && bytesReceivedSpeed > _minThresholdSpeed)
                {
                    currentNetworkSpeed += bytesReceivedSpeed;
                    accountedTests++;
                    lock (_valores)
                    {
                        _valores.Enqueue(bytesReceivedSpeed);
                    }
                }
                System.Threading.Thread.Sleep(500);
            }
            //Ao término dos testes, faz a média das velocidades obtidas eliminando o primeiro que é acumulado dos passados
            if (_valores.Count > 1)
            {
                var discrepancia = _valores.Dequeue();

                currentNetworkSpeed = (currentNetworkSpeed - discrepancia) / accountedTests;
            }

            //Salva velocidade atual na chave de configuração no banco
            _configurationRepository.UpdateNetworkBandwidthKey(this.FindRangeNetworkBandwidthStatus(currentNetworkSpeed));
            _valores.Clear();

            Console.WriteLine("---------" + currentNetworkSpeed + "KB/s /n\n");
        }

        //Retorna a faixa parametrizada em que se encaixa a velocidade
        private NetworkBandwidthMonitorStatus FindRangeNetworkBandwidthStatus(double velocidadeAtual)
        {
            //Calcula a porcentagem do valor atual em realação ao valor de velocidade máxima
            double porcentagemFinalDeUso = (velocidadeAtual * 100) / (this._maxSpeedLink / 8);
            if (porcentagemFinalDeUso <
                double.Parse((_configurationRepository.GetConfigurationValue(ConfigurationKey.OK_NETWORK_MAX_USAGE_PERCENTUAL))))
            {
                return NetworkBandwidthMonitorStatus.OK;
            }
            else if (porcentagemFinalDeUso <
               double.Parse((_configurationRepository.GetConfigurationValue(ConfigurationKey.WARNING_NETWORK_MAX_USAGE_PERCENTUAL))))
            {
                return NetworkBandwidthMonitorStatus.WARNING;
            }
            else
            {
                return NetworkBandwidthMonitorStatus.CRITICAL;
            }
        }

        private void LoadConfigurationValuesForAttributes()
        {
            //Captura a interface da rede utilizada
            foreach (NetworkInterface currentNetworkInterface in NetworkInterface.GetAllNetworkInterfaces()){
                if (currentNetworkInterface.OperationalStatus.ToString() == "Up")
                {
                    _networkInterface = currentNetworkInterface;
                    _configurationRepository = new ConfigurationRepository();
                    break;
                }
            }
            using ( var configurationRepository = new ConfigurationRepository())
            {
                Dictionary<string,string> attributesValues = configurationRepository.GetNetworkBandwidthMonitorServiceConfigurations();
                this._testSpeedQuantity = int.Parse(attributesValues.Where(p=>p.Key == ConfigurationKey.TEST_SPEED_QUANTITY.ToString())
                                                                             .Select(p=>p.Value)
                                                                             .Single());
                this._maxSpeedLink = int.Parse(attributesValues.Where(p => p.Key == ConfigurationKey.MAX_SPEED_LINK.ToString())
                                                                             .Select(p => p.Value)
                                                                             .Single());
                this._maxThresholdSpeed = int.Parse(attributesValues.Where(p => p.Key == ConfigurationKey.MAX_THRESHOLD_SPEED.ToString())
                                                             .Select(p => p.Value)
                                                             .Single());
                this._minThresholdSpeed = int.Parse(attributesValues.Where(p => p.Key == ConfigurationKey.MIN_THRESHOLD_SPEED.ToString())
                                             .Select(p => p.Value)
                                             .Single());
                this._intervalTimerNetworkVerification = int.Parse(attributesValues.Where(p => p.Key == ConfigurationKey.INTERVAL_TIMER_NETWORK_VERIFICATION.ToString())
                                             .Select(p => p.Value)
                                             .Single());
            }
            this._valores = new Queue<double>();
        }

        ////Timer para download de um arquivo temporário
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    string url = @"http://www.microsoft.com/downloads/info.aspx?na=41&srcfamilyid=92ced922-d505-457a-8c9c-84036160639f&srcdisplaylang=en&u=http%3a%2f%2fdownload.microsoft.com%2fdownload%2f2%2f9%2f6%2f296AAFA4-669A-46FE-9509-93753F7B0F46%2fVS-KB-Brochure-CSharp-Letter-HiRez.pdf";
        //    WebClient client = new WebClient();

        //    //Função de evento após download assincrono
        //    client.DownloadFileCompleted += new AsyncCompletedEventHandler(deleteTempFileDownload);
        //    tempFileName = Path.GetTempFileName();
        //    client.DownloadFileAsync(new Uri(url), tempFileName);
        //}

        ////Remove arquivo temporário
        //private void deleteTempFileDownload(object sender, AsyncCompletedEventArgs e)
        //{
        //    try
        //    {
        //        //Log do total
        //        double total = 0;
        //        int totalRegistros = valores.Count;
        //        while (valores.Count > 0)
        //        {
        //            lock (valores)
        //            {
        //                total += valores.Dequeue();
        //            }
        //        }
        //        Console.WriteLine(total / totalRegistros);
        //        Console.WriteLine("BAIXADO");
        //        if (File.Exists(tempFileName))
        //        {
        //            File.Delete(tempFileName);
        //        }

        //    }
        //    catch (Exception ex) { }
        //}

        /*Para calcular a velocidade usa-se a velocidade anunciada / por 8. Por exemplo internet 15MB (15000KB) a velocidade máxima de download será 1875kb/s*/
    }
}
