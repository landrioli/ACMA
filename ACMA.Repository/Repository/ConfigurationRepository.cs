using ACMA.Domain.Entities.Commom;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ACMA.Domain.Entities.RFID;
using ACMA.Domain.Entities.ActiveAsset;
using ACMA.Domain.Entities.NetworkBandwidth;

namespace ACMA.Repository.Repository
{
    public class ConfigurationRepository : RootBaseRepository
    {
        public void SaveConfiguration(Configuration configuration)
        {
            using (var context = new Context())
            {
                context.Entry(configuration).State = configuration.Id == 0 ? EntityState.Added : EntityState.Modified;
            }
        }

        public void UpdateNetworkBandwidthKey(NetworkBandwidthMonitorStatus networkBandwidthMonitorStatus)
        {
            using (var context = new Context())
            {
                var key = context.Configurations.Where(p => p.Key == ConfigurationKey.CURRENT_NETWORK_STATUS.ToString())
                                                .Single();
                context.Configurations.Attach(key);
                key.Value = networkBandwidthMonitorStatus.ToString();
                context.Entry(key).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public string GetConfigurationValue(ConfigurationKey configurationKey)
        {
            using (var context = new Context())
            {
                return context.Configurations.Where(p => p.Key == configurationKey.ToString())
                                             .Select(p => p.Value)
                                             .Single();
            }
        }

        public Dictionary<string, string> GetNetworkBandwidthMonitorServiceConfigurations()
        {
            using (var context = new Context())
            {
                return context.Configurations.Where(p => p.Key == ConfigurationKey.INTERVAL_TIMER_NETWORK_VERIFICATION.ToString() ||
                                                         p.Key == ConfigurationKey.MAX_SPEED_LINK.ToString() ||
                                                         p.Key == ConfigurationKey.TEST_SPEED_QUANTITY.ToString() ||
                                                         p.Key == ConfigurationKey.MAX_THRESHOLD_SPEED.ToString() ||
                                                         p.Key == ConfigurationKey.MIN_THRESHOLD_SPEED.ToString())
                                             .Select(p => new { p.Key, p.Value })
                                             .ToDictionary(p => p.Key, p => p.Value);
            }
        }

        public Dictionary<string, string> GetCaptureAndFilteringDataServiceConfigurations()
        {
            using (var context = new Context())
            {
                return context.Configurations.Where(p => p.Key == ConfigurationKey.INTERVAL_SEND_DATA_TO_DATABASE.ToString() ||
                                                         p.Key == ConfigurationKey.PORT.ToString() ||
                                                         p.Key == ConfigurationKey.SERVER_IPADDRESS.ToString())
                                             .Select(p => new { p.Key, p.Value })
                                             .ToDictionary(p => p.Key, p => p.Value);
            }
        }
    }
}
