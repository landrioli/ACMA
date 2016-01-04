using ACMA.Domain.Entities.RFID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMA.CaptureAndFilteringDataService.FormatterService
{
    public class FormatterService : IDisposable
    {
        public List<RawData> FormatIncomingData(List<RawData> rawDataList, string incomingData)
        {
            string[] content = incomingData.Replace(" ", "").Split(new string[] { "\r\n" }, StringSplitOptions.None);

            if (content[8].IndexOf("(NoTags)") == -1)
            {
                var posInicioIpAddress = 11;
                var posTerminoIpAddress = (content[2].Length - posInicioIpAddress);
                var posInicioIpPorta = 13;
                var posTerminoPorta = (content[3].Length - posInicioIpPorta);
                var posInicioData = 6;
                var posTerminoData = (content[4].Length - posInicioData) + 1;

                var date = DateTime.Parse(incomingData.Split(new string[] { "\r\n" }, StringSplitOptions.None)[4].Substring(posInicioData, posTerminoData));
                var ipAdress = content[2].Substring(posInicioIpAddress, posTerminoIpAddress) + ":" +
                               content[3].Substring(posInicioIpPorta, posTerminoPorta);

                for (int i = 8; i < (content.Length - 2); i++)
                {
                    var tag = content[i].Substring(0, content[i].IndexOf(",0,"));
                    var rawData = new RawData();
                    rawData.TagCode = tag;
                    rawData.DateRegistration = date;
                    rawData.IpAddress = ipAdress;

                    lock (rawDataList)
                    {
                        rawDataList.Add(rawData);
                    }
                }
            }
            return rawDataList;
        }

        public void Dispose()
        {
        }
    }
}
