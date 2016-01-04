using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACMA.Domain.Entities.ActiveAsset;
using ACMA.Domain.Entities.Common;

namespace ACMA.Domain.Entities.RFID
{
    public class Tag : EntityBase
    {
        public string TagCode { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Item> Item { get; set; }

    }
}
