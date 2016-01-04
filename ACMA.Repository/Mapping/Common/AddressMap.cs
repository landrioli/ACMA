using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.Common
{
    public class AddressMap : ComplexTypeConfiguration<Address>
    {
        public AddressMap()
        {
            //Complex type has no configuration//
        }
    }
}
