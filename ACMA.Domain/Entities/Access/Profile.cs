using ACMA.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.Access
{
    public class Profile : EntityBase
    {
        public Profile()
        {
            AccessProfile = new List<AccessProfile>();
        }
        public string Value { get; set; }
        public virtual ICollection<AccessProfile> AccessProfile{ get; set; }
    }
}
