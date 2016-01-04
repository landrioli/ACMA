using ACMA.Domain.Entities.Common;
using ACMA.Domain.Entities.Place;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace ACMA.Domain.Entities.Place
{
    public class UnitMap : EntityTypeConfiguration<Unit>
    {
        public UnitMap()
        {
            ToTable("Unit");

            Property(p => p.Id).HasColumnName("Id");
            Property(p => p.Active).IsRequired();
            Property(p => p.Cnpj).HasMaxLength(14).IsRequired();
            Property(p => p.Name).HasMaxLength(120).IsRequired();

            Property(p => p.Address.City).HasMaxLength(80).HasColumnName("AddressCity").IsRequired();
            Property(p => p.Address.Neighborhood).HasMaxLength(80).HasColumnName("AddressNeighborhood").IsRequired();
            Property(p => p.Address.Number).HasMaxLength(10).HasColumnName("AddressNumber").IsRequired();
            Property(p => p.Address.State).HasMaxLength(80).HasColumnName("AddressState").IsRequired();
            Property(p => p.Address.Street).HasMaxLength(80).HasColumnName("AddressStreet").IsRequired();
            Property(p => p.Address.ZipCode).HasMaxLength(8).HasColumnName("AddressZipCode").IsRequired();
        }
    }
}
