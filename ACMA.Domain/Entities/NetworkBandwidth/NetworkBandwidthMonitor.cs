using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ACMA.Domain.Entities.NetworkBandwidth
{
    public class NetworkBandwidthMonitor
    {
       public NetworkInterface networkInterface { get; set; }
       public long TotalBytesEnviados { get; set; }
       public long TotalBytesRecebidos { get; set; }
       public string tempFileName { get; set; }
       public Queue<double> valores { get; set; }
       public int QuantidadeDeTestes { get; set; }
       public double VelocidadeLinkContratado { get; set; }
       public double LimiarMaxima { get; set; }
       public double LimiarMinima { get; set; }
       public double IntervalOfNetworkVerification { get; set; }
       public Timer timerNetworkBandwidthMonitor { get; set; }

       public NetworkBandwidthMonitor()
       {
           this.valores = new Queue<double>();
       }

    }
}
