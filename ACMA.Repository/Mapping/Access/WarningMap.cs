using ACMA.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.Access
{
    public class WarningMap : EntityTypeConfiguration<Warning>
    {
        public WarningMap()
        {
            ToTable("Warning");

            Property(p => p.Id).HasColumnName("Id");

            Property(p => p.Description).HasMaxLength(120).IsRequired(); ;
            Property(p => p.Readed).IsRequired();

            HasRequired(p => p.WarningGroup).WithMany(p => p.Warning).HasForeignKey(p => p.IdWarningGroup);
            HasRequired(p => p.User).WithMany(p => p.Warning).HasForeignKey(p => p.IdUser);
        }
    }
}
