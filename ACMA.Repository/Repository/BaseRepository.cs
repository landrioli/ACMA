using ACMA.Domain.Entities.Common;
using Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACMA.Repository.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
       public Context Context;

        public BaseRepository()
        {
            this.Context = new Context();
        }

        public BaseRepository(Context Context)
        {
            this.Context = Context;
        }

        public T Add(T instance)
        {
            return Context.Set<T>().Add(instance);
        }

        public void Remove(int id)
        {
            var instancia = Context.Set<T>().Find(id);

            if (instancia == null)
            {
               // throw new EntidadeNaoPodeSerRemovidaException(RepositorioExcecoes.EntidadeNaoPodeSerRemovidaException);
            }

            Context.Set<T>().Remove(instancia);
        }

        public T GetById(int id)
        {
            var instancia = Context.Set<T>().Find(id);

            if (instancia == null)
            {
                //throw new EntidadeNaoLocalizadaPorIdentificadorException(RepositorioExcecoes.EntidadeNaoLocalizadaPorIdentificadorException);
            }
            return instancia;
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }
    }
}
