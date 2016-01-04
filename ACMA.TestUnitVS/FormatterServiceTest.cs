using ACMA.Application.Services;
using ACMA.CaptureAndFilteringDataService.FormatterService;
using ACMA.Domain.Entities.RFID;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMA.TestUnitVS
{
    [TestClass]
    public class FormatterServiceTest
    {
        [TestMethod]
        public void FormatterService()
        {
            var multiTag = "#Alien RFID Reader Auto Notification Message#ReaderName: Alien RFID Reader\r\n#ReaderType: Alien RFID Tag Reader, Model: ALR-9800 (Four Antenna / Multi-Protocol / 915 MHz)\r\n#IPAddress: 10.99.2.129\r\n#CommandPort: 4001\r\n#Time: 2015/12/30 09:12:16\r\n#Reason: TIMED MESSAGE\r\n#StartTriggerLines: 0\r\n#StopTriggerLines: 0\r\n35E4 4B57 3390 000A 0F29 B40A,0,1\r\n35F3 8410 8DEE 8E8B 377E F26D,0,1\r\n35F9 78AB AAEB 521C 5CD9 8367,0,1\r\n35A3 6B84 9EF5 296E FB15 9AC5,0,1\r\n#Alien RFID Reader Auto Notification Message\r\n\0";
            var oneTag = "#Alien RFID Reader Auto Notification Message#ReaderName: Alien RFID Reader\r\n#ReaderType: Alien RFID Tag Reader, Model: ALR-9800 (Four Antenna / Multi-Protocol / 915 MHz)\r\n#IPAddress: 10.99.2.129\r\n#CommandPort: 4001\r\n#Time: 2015/12/30 09:11:36\r\n#Reason: TIMED MESSAGE\r\n#StartTriggerLines: 0\r\n#StopTriggerLines: 0\r\n35E4 4B57 3390 000A 0F29 B40A,0,1\r\n#Alien RFID Reader Auto Notification Message\r\n\0";
            var noTag = "#Alien RFID Reader Auto Notification Message#ReaderName: Alien RFID Reader\r\n#ReaderType: Alien RFID Tag Reader, Model: ALR-9800 (Four Antenna / Multi-Protocol / 915 MHz)\r\n#IPAddress: 10.99.2.129\r\n#CommandPort: 4001\r\n#Time: 2015/12/30 09:10:36\r\n#Reason: TIMED MESSAGE\r\n#StartTriggerLines: 0\r\n#StopTriggerLines: 0\r\n(No Tags)\r\n#Alien RFID Reader Auto Notification Message\r\n\0";
            FormatterService fs = new FormatterService();
            var list = new List<RawData>();
            var result = fs.FormatIncomingData(list, multiTag);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SaveFormattedRawData()
        {
            var rawData1 = new RawData() { DateRegistration = DateTime.Parse("2015/12/30 09:10:36"), IpAddress = "10.99.2.129:4001", TagCode = "35E44B573390000A0F29B40A" };
            var rawData2 = new RawData() { DateRegistration = DateTime.Parse("2015/12/30 09:10:40"), IpAddress = "10.99.2.129:4002", TagCode = "35F384108DEE8E8B377EF26D" };
            var rawData3 = new RawData() { DateRegistration = DateTime.Parse("2015/12/30 11:11:36"), IpAddress = "10.99.2.129:4003", TagCode = "35F978ABAAEB521C5CD98367" };
            var list = new List<RawData>();
            list.Add(rawData1);
            list.Add(rawData2);
            list.Add(rawData3);

            using (var activeAssetService = new ActiveAssetService())
            {
                activeAssetService.SaveFormattedRawData(list);
            }
        }
    }
}
