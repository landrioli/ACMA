using ACMA.Domain.Entities.Common;
using ACMA.Domain.Entities.Place;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.RFID
{
    class ReaderMap : EntityTypeConfiguration<Reader>
    {
        public ReaderMap()
        {
            ToTable("Reader");

            Property(p => p.Id).HasColumnName("Id");

            Property(p => p.IpAddress).HasMaxLength(20).IsRequired();
            Property(p => p.Location).HasMaxLength(50).IsRequired();

            HasRequired(p => p.CostCenter).WithMany(p => p.Reader).HasForeignKey(s => s.IdCostCenter);
            HasRequired(p => p.ReaderStatus).WithMany(p => p.Reader).HasForeignKey(p => p.IdReaderStatus);
            HasRequired(p => p.Unit).WithMany(p => p.Reader).HasForeignKey(s => s.IdUnit);
        }
    }
}
