using ACMA.Domain.Entities.Common;
using Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACMA.Repository.Repository
{
    public class RootBaseRepository : IRootBaseRepository<EntityBase>, IDisposable
    {
        public Context Context { get; set; }

        public RootBaseRepository()
        {
            this.Context = new Context();
        }

        public RootBaseRepository(Context context)
        {
            this.Context = Context;
        }

        public void Add(EntityBase instance)
        {
            Context.Set<EntityBase>().Add(instance);
        }

        public void Remover(int id)
        {
            var instancia = Context.Set<EntityBase>().Find(id);

            if (instancia == null)
            {
                //throw new EntidadeNaoPodeSerRemovidaException(RepositorioExcecoes.EntidadeNaoPodeSerRemovidaException);
            }

            Context.Set<EntityBase>().Remove(instancia);
        }

        public EntityBase GetBy(int id)
        {
            var instancia = Context.Set<EntityBase>().Find(id);

            if (instancia == null)
            {
                //throw new EntidadeNaoLocalizadaPorIdentificadorException(repositorioExcecoes.EntidadeNaoLocalizadaPorIdentificadorException);
            }
            return instancia;
        }

        public List<EntityBase> GetAll()
        {
            return Context.Set<EntityBase>().ToList();
        }

        public void Dispose()
        {
        }
    }
}
