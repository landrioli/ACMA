using ACMA.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.Access
{
    public class AccessProfile : EntityBase
    {
        public AccessProfile()
        {
            User = new List<User>();
        }

        public string Key { get; set; }
        public string Description { get; set; }

        public int IdProfile { get; set; }
        public Profile Profile { get; set; }

        public virtual ICollection<User> User { get; set; }

    }
}
