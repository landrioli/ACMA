using ACMA.Domain.Entities.Commom;
using ACMA.Domain.Entities.NetworkBandwidth;
using ACMA.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ACMA.NetworkBandwidthMonitorService
{
    public class NetworkServiceTest : ServiceBase
    {
        public NetworkInterface _networkInterface { get; set; }
        public long _totalBytesSend { get; set; }
        public long _totalBytesReceived{ get; set; }
        public string _tempFileName { get; set; }
        public Queue<double> _valores { get; set; }
        public int _testSpeedQuantity { get; set; }
        public double _maxSpeedLink { get; set; }
        public double _maxThresholdSpeed { get; set; }
        public double _minThresholdSpeed { get; set; }
        public double _intervalOfNetworkVerification { get; set; }
        public Timer _timerNetworkBandwidthMonitor { get; set; }
        public ConfigurationRepository _configurationRepository { get; set; }

        public NetworkServiceTest()
        {
            foreach (NetworkInterface currentNetworkInterface in NetworkInterface.GetAllNetworkInterfaces())
                if (currentNetworkInterface.OperationalStatus.ToString() == "Up")
                {
                    _networkInterface = currentNetworkInterface;
                    _configurationRepository = new ConfigurationRepository();
                    break;
                }
        }

        protected void OnStart()
        {
            //Timmer para verificação da velocidade da internet
            _timerNetworkBandwidthMonitor = new Timer();
            _timerNetworkBandwidthMonitor.Elapsed += new ElapsedEventHandler(OnElapsedTimerNetworkBandwidthMonitor);
            _timerNetworkBandwidthMonitor.Interval = _intervalOfNetworkVerification;
            _timerNetworkBandwidthMonitor.Enabled = true;
        }

        protected void OnStop()
        {
            _timerNetworkBandwidthMonitor.Enabled = false;
        }

        private void OnElapsedTimerNetworkBandwidthMonitor(object sender, ElapsedEventArgs e)
        {
            CalculaEstimativaVelocidadeAtual();
        }

        public void CalculaEstimativaVelocidadeAtual()
        {
            double velocidadeAtual = 0;
            for (int i = 0; i < _testSpeedQuantity; i++)
            {
                //Pega estatisticas da interface atual
                IPv4InterfaceStatistics interfaceStatistic = _networkInterface.GetIPv4Statistics();

                //Velocidade bytes enviados = total de bytes enviado até esta interação - total de bytes enviados até ultima checkagem
                int bytesSentSpeed = (int)(interfaceStatistic.BytesSent - _totalBytesSend) / 1024;

                //Velocidade bytes recebidos = total de bytes recebidos até esta interação - total de bytes recebidos até ultima checkagem
                int bytesReceivedSpeed = (int)(interfaceStatistic.BytesReceived - _totalBytesReceived) / 1024;

                //Mostra na interface Grafica a velocidade em real time
                //lblUpload.Text = bytesSentSpeed.ToString() + " KB/s";
                //lblDownLoad.Text = bytesReceivedSpeed.ToString() + " KB/s ";

                //Atualiza a quantidade de dados recebidos na iteração
                _totalBytesSend = interfaceStatistic.BytesSent;
                _totalBytesReceived = interfaceStatistic.BytesReceived;

                //Verifica limiares que fujam da normalidade - Picos que acontecem por acaso
                if (!(bytesReceivedSpeed > _maxThresholdSpeed || bytesReceivedSpeed < _minThresholdSpeed))
                {
                    velocidadeAtual += bytesReceivedSpeed;
                    Console.WriteLine(bytesReceivedSpeed);

                    lock (_valores)
                    {
                        _valores.Enqueue(bytesReceivedSpeed);
                    }
                }
                System.Threading.Thread.Sleep(500);
            }
            //Ao término dos testes, faz a média das velocidades obtidas
            var discrepancia = _valores.Dequeue();
            velocidadeAtual = (velocidadeAtual - discrepancia) / this._testSpeedQuantity;

            //Salva velocidade atual na chave de configuração no banco
            _configurationRepository.UpdateNetworkBandwidthKey(this.FindRangeNetworkBandwidthStatus(velocidadeAtual));
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

        private void LoadConfigurationValuesFor(NetworkBandwidthMonitor networkBandwidthMonitor)
        {
            using (var configurationRepository = new ConfigurationRepository())
            {

            }
        }
    }
}
