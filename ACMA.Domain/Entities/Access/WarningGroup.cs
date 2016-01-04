using ACMA.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.Access
{
    public class WarningGroup : EntityBase
    {
        public string Value { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Warning> Warning { get; set; }
    }
}
