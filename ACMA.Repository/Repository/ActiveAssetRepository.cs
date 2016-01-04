using ACMA.Domain.Entities.ActiveAsset;
using ACMA.Domain.Entities.Common;
using Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ACMA.Repository.Repository
{
    public class ActiveAssetRepository : RootBaseRepository
    {
        public void SaveFormattedRawData(List<Asset> assetList)
        {
            using (var context = new Context())
            {
                foreach (var asset in assetList)
                {
                    context.Entry(asset).State = EntityState.Added;
                }
                context.SaveChanges();
            }
        }
    }
}
