using ACMA.Domain.Entities.Common;
using ACMA.Domain.Entities.Place;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.RFID
{
    public class Reader : EntityBase
    {
        public string IpAddress { get; set; }
        public string Location { get; set; }

        public int IdCostCenter { get; set; }
        public CostCenter CostCenter { get; set; }
        public int IdReaderStatus { get; set; }
        public ReaderStatus ReaderStatus { get; set; }
        public int IdUnit{ get; set; }
        public Unit Unit { get; set; }
    }
}
