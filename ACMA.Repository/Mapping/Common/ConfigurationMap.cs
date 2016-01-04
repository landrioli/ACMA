using ACMA.Domain.Entities.Commom;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMA.Repository.Mapping.Common
{
    public class ConfigurationMap : EntityTypeConfiguration<Configuration>
    {
        public ConfigurationMap()
        {
            ToTable("Configuration");

            Property(p => p.Id).HasColumnName("Id");

            Property(p => p.Key).HasMaxLength(80).IsRequired();
            Property(p => p.Value).HasMaxLength(80).IsRequired();
            Property(p => p.Description).HasMaxLength(120).IsRequired();
            Property(p => p.DateLastUpdated).IsRequired();
        }

    }
}
