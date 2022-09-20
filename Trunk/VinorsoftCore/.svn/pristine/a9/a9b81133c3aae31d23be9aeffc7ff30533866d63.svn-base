using KTApps.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KTApps.Core.EF
{
    public interface IUnitOfWork
    {
        ICatalogueRepository<T> CatalogueRepository<T>() where T : KTAppDomainCatalogue;
        IDomainRepository<T> Repository<T>() where T : KTAppDomain;
        void Save();
        Task SaveAsync();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));
    }
}
