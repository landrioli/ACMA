using ACMA.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMA.Domain.Entities.Commom
{
    public class Configuration : EntityBase
    {
        public virtual string Key { get; set; }

        public virtual string Value { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime DateLastUpdated { get; set; }
    }
}
