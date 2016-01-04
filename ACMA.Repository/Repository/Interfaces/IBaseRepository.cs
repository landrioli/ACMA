using ACMA.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        T Add(T instance);
        void Remove(int id);

        T GetById(int id);
        List<T> GetAll();
    }
}
