using ACMA.Domain.Entities.Common;
using ACMA.Domain.Entities.ActiveAsset;
using ACMA.Domain.Entities.RFID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.Place
{
    public class CostCenter : EntityBase
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public ICollection<Reader> Reader { get; set; }
        public ICollection<Asset> Asset { get; set; }
        public ICollection<Item> Item { get; set; }
    }
}
