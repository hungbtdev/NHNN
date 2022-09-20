using KTApps.Core.Factory;
using KTApps.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace KTApps.Core.EF
{
    public class CatalogueRepository<T> : DomainRepository<T>, ICatalogueRepository<T> where T : KTAppDomainCatalogue
    {
        public CatalogueRepository(ICoreDbContext context) : base(context)
        {

        }
        public CatalogueRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public T GetByCode(string code)
        {
            return Context.Set<T>().FirstOrDefault(e => e.Code == code);
        }

        public void Delete(Guid id)
        {
            T entity = Context.Set<T>().FirstOrDefault(e => e.Id == id);
            entity.Deleted = true;
            Context.Set<T>().Update(entity);
        }
        public override void Delete(T entity)
        {
            entity.Deleted = true;
            Context.Set<T>().Update(entity);
        }
    }
}
