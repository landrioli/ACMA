using ACMA.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.RFID
{
    public class RawData : EntityBase
    {
        public string TagCode { get; set; }
        public string IpAddress { get; set; }
    }
}
