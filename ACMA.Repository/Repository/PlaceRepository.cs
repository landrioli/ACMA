using ACMA.Domain.Entities.Place;
using Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACMA.Repository.Repository
{
    public class PlaceRepository : RootBaseRepository
    {
        public CostCenter GetCostCenterBy(int idCostCenter) {
            using (var context = new Context())
            {
                return context.CostCenter.Where(p => p.Id == idCostCenter).SingleOrDefault();
            }
        }

        public Unit GetUnitBy(int idUnit)
        {
            using (var context = new Context())
            {
                return context.Unit.Where(p => p.Id == idUnit).SingleOrDefault();
            }
        }

        public int GetCostCenterIdBy(string ipAddressReader)
        {
            using (var context = new Context())
            {
                return context.Reader.Where(p => p.IpAddress == ipAddressReader).Select(p => p.IdCostCenter).FirstOrDefault();
            }
        }

        public int GetUnitIdBy(string ipAddressReader)
        {
            using (var context = new Context())
            {
                return context.Reader.Where(p => p.IpAddress == ipAddressReader).Select(p => p.IdUnit).FirstOrDefault();
            }
        }
    }
}
