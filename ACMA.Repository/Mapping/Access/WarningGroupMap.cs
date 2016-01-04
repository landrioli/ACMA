using ACMA.Domain.Entities.Common;
using ACMA.Domain.Entities.Access;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.Access
{
    public class WarningGroupMap : EntityTypeConfiguration<WarningGroup>
    {
        public WarningGroupMap()
        {
            ToTable("WarningGroup");

            Property(p => p.Id).HasColumnName("Id");
            Property(p => p.Value).HasMaxLength(80).IsRequired();
            Property(p => p.Description).HasMaxLength(120).IsRequired();
        }
    }
}
