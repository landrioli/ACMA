using ACMA.Domain.Entities.Common;
using ACMA.Domain.Entities.Place;
using ACMA.Domain.Entities.RFID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.ActiveAsset
{
    public class Asset : EntityBase
    {
        public int IdItem { get; set; }
        public Item Item { get; set; }
        public int IdUnit { get; set; }
        public Unit Unit { get; set; }
        public int IdCostCenter { get; set; }
        public CostCenter CostCenter { get; set; }
    }
}
