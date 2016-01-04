using ACMA.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.Access
{
    public class Warning : EntityBase
    {
        public string Description { get; set; }
        public bool Readed { get; set; }

        public int IdWarningGroup { get; set; }
        public WarningGroup WarningGroup { get; set; }

        public int IdUser { get; set; }
        public User User { get; set; }
    }
}
