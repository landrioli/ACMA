using ACMA.Domain.Entities.Common;
using ACMA.Domain.Entities.Access;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.Access
{
    public class AccessProfileMap : EntityTypeConfiguration<AccessProfile>
    {
        public AccessProfileMap()
        {
            ToTable("AccessProfile");

            Property(p => p.Id).HasColumnName("Id");

            Property(p => p.Key).HasMaxLength(80).IsRequired();
            Property(p => p.Description).HasMaxLength(120).IsOptional();

            HasRequired(p => p.Profile).WithMany(p => p.AccessProfile).HasForeignKey(s => s.IdProfile);
        }
    }
}
