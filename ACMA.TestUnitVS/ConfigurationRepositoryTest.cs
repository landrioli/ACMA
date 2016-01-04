using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACMA.Repository.Repository;
using ACMA.Domain.Entities.Commom;
using System.Collections.Generic;
using ACMA.Domain.Entities.NetworkBandwidth;

namespace ACMA.TestUnitVS
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void GetConfiguration()
        {
            var repo = new ConfigurationRepository();
            var result = repo.GetConfigurationValue(ConfigurationKey.CURRENT_NETWORK_STATUS);
            Assert.AreEqual(result, ConfigurationKey.CURRENT_NETWORK_STATUS.ToString());
        }

        [TestMethod]
        public void UpdateNetworkBandwidthKey()
        {
            var repo = new ConfigurationRepository();
            repo.UpdateNetworkBandwidthKey(NetworkBandwidthMonitorStatus.WARNING);
            var result = repo.GetConfigurationValue(ConfigurationKey.CURRENT_NETWORK_STATUS);
            Assert.AreEqual(result, ConfigurationKey.CURRENT_NETWORK_STATUS.ToString());
        }

        [TestMethod]
        public void GetNetworkBandwidthMonitorServiceConfigations()
        {
            var repo = new ConfigurationRepository();
            Dictionary<string,string> result = repo.GetNetworkBandwidthMonitorServiceConfigurations();
            Assert.AreEqual(result.Count,5);
        }


    }
}
