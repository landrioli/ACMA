using ACMA.Domain.Entities.Common;
using ACMA.Domain.Entities.Place;
using ACMA.Domain.Entities.RFID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.ActiveAsset
{
    public class Item : EntityBase
    {
        public int IdUnit { get; set; }
        public Unit Unit { get; set; }
        public int IdCostCenter { get; set; }
        public CostCenter CostCenter { get; set; }
        public int IdTag { get; set; }
        public Tag Tag { get; set; }

        public double Value { get; set; }
        public string Responsable { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Asset> Asset { get; set; }
    }
}
