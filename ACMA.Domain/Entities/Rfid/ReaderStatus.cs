using ACMA.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.RFID
{
    public class ReaderStatus : EntityBase
    {
        public bool Available { get; set; }
        public bool Notified { get; set; }
        public DateTime LastCheck { get; set; }

        public virtual ICollection<Reader> Reader { get; set; }
    }
}
