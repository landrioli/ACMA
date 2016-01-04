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
    public class AssetMap : EntityTypeConfiguration<Asset>
    {
        public AssetMap()
        {
            ToTable("Asset");

            Property(p => p.Id).HasColumnName("Id");

            HasRequired(p => p.CostCenter).WithMany(p => p.Asset).HasForeignKey(s => s.IdCostCenter);
            HasRequired(p => p.Item).WithMany(p => p.Asset).HasForeignKey(s => s.IdItem);
            HasRequired(p => p.Unit).WithMany(p => p.Asset).HasForeignKey(s => s.IdUnit);
        }
    }
}
