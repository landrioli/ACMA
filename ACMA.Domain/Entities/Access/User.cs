
using ACMA.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.Access
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Blocked { get; set; }
        public bool Active { get; set; }

        public Contact Contact { get; set; }
        public int IdProfile { get; set; }
        public AccessProfile AccessProfile { get; set; }

        public ICollection<Warning> Warning { get; set; }
    }
}
