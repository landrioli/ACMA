using ACMA.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACMA.Domain.Entities.ActiveAsset;
using ACMA.Domain.Entities.RFID;

namespace ACMA.Domain.Entities.Place
{
    public class Unit : EntityBase
    {
        public string Cnpj { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public bool Active { get; set; }

        public ICollection<Reader> Reader { get; set; }
        public ICollection<Asset> Asset { get; set; }
        public ICollection<Item> Item { get; set; }
    }
}
