using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.RFID
{
    public class TagMap : EntityTypeConfiguration<Tag>
    {
        public string TagCode { get; set; }
        public bool Active { get; set; }

        public TagMap()
        {
            Property(p => p.Active).IsRequired();
            Property(p => p.TagCode).HasMaxLength(50).IsRequired();
        }
    }
}
