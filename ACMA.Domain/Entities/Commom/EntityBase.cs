using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.Common
{
    public class EntityBase
    {
        public EntityBase()
        {
            DateRegistration = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime DateRegistration { get; set; }
    }
}
