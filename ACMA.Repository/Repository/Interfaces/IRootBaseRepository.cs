using ACMA.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repository.Interfaces
{
    public interface IRootBaseRepository<T> where T : class
    {
        void Add(T instance);

        void Remover(int id);

        T GetBy(int id);

        List<T> GetAll();
    }
}
