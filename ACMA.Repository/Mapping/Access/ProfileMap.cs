using ACMA.Domain.Entities.Access;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.Access
{
    public class ProfileMap : EntityTypeConfiguration<Profile>
    {
        public ProfileMap()
        {
            ToTable("Profile");

            Property(p => p.Id).HasColumnName("Id");

            Property(p => p.Value).HasMaxLength(50).IsRequired();
        }
    }
}
