
using ACMA.Domain.Entities.Common;
using ACMA.Domain.Entities.Access;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.Access
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");

            Property(p => p.Id).HasColumnName("Id");

            Property(p => p.Contact.Email).HasMaxLength(80).HasColumnName("ContactFullName").IsRequired();
            Property(p => p.Contact.FullName).HasMaxLength(80).HasColumnName("ContactEmail").IsRequired();
            Property(p => p.Contact.Phone).HasMaxLength(11).HasColumnName("ContactPhone").IsRequired();
            
            Property(p => p.UserName).HasMaxLength(20).IsRequired();
            Property(p => p.Password).HasMaxLength(30).IsRequired();

            HasRequired(p => p.AccessProfile).WithMany(p => p.User).HasForeignKey(p => p.IdProfile);
        }
    }
}
