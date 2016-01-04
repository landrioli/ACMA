using ACMA.Domain.Entities.Common;
using ACMA.Domain.Entities.Place;
using ACMA.Domain.Entities.RFID;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.ActiveAsset
{
    public class ItemMap : EntityTypeConfiguration<Item>
    {
        public ItemMap()
        {
            ToTable("Item");

            Property(p => p.Id).HasColumnName("Id");

            Property(p => p.Value).IsRequired();
            Property(p => p.Responsable).IsRequired();
            Property(p => p.Active).IsRequired();

            HasRequired(p => p.CostCenter).WithMany(p => p.Item).HasForeignKey(s => s.IdCostCenter);
            HasRequired(p => p.Tag).WithMany(p => p.Item).HasForeignKey(s => s.IdTag);
            HasRequired(p => p.Unit).WithMany(p => p.Item).HasForeignKey(s => s.IdUnit);
        }
    }
}
