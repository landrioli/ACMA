using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.Common
{
    public class ContactMap : ComplexTypeConfiguration<Contact>
    {
        public ContactMap()
        {
           //Complex type has no configuration//
        }
    }
}
