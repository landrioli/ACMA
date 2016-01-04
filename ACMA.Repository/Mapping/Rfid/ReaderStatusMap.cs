using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.RFID
{
    public class ReaderStatusMap : EntityTypeConfiguration<ReaderStatus>
    {
        public ReaderStatusMap()
        {
            ToTable("ReaderStatus");

            Property(p => p.Id).HasColumnName("Id");

            Property(p => p.Available).IsRequired();
            Property(p => p.Notified).IsRequired();
            Property(p => p.LastCheck).IsRequired();
        }
    }
}
