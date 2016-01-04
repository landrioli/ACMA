using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.RFID
{
    class RawDataMap : EntityTypeConfiguration<RawData>
    {
        public RawDataMap()
        {
            ToTable("RawData");

            Property(p => p.Id).HasColumnName("Id");

            Property(p => p.IpAddress).HasMaxLength(20).IsRequired();
            Property(p => p.TagCode).HasMaxLength(50).IsRequired();

        }
    }
}
