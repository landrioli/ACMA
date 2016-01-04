using ACMA.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.Place
{
    public class CostCenterMap : EntityTypeConfiguration<CostCenter>
    {
        public CostCenterMap()
        {
            ToTable("CostCenter");

            Property(p => p.Id).HasColumnName("Id");
            Property(p => p.Active).IsRequired();
            Property(p => p.Code).IsRequired();
            Property(p => p.Description).HasMaxLength(120).IsRequired();
            Property(p => p.Name).HasMaxLength(120).IsRequired();

        }
    }
}
