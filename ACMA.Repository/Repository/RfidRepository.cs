using Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACMA.Repository.Repository
{
    public class RfidRepository : RootBaseRepository
    {

        public int GetReaderIdBy(string ipAddressReader)
        {
            using (var context = new Context())
            {
                return context.Reader.Where(p => p.IpAddress == ipAddressReader).Select(p => p.Id).SingleOrDefault();
            }
        }

        public int GetItemIdBy(string tagCode)
        {
            using (var context = new Context())
            {
                return context.Item.Where(p => p.Tag.TagCode == tagCode).Select(p => p.Id).SingleOrDefault();
            }
        }
    }
}
