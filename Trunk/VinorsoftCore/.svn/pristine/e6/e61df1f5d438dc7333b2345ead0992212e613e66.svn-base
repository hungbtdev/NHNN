using System.Threading;
using System.Threading.Tasks;
using KTApps.Core.Factory;
using KTApps.Domain;
using Microsoft.EntityFrameworkCore;

namespace KTApps.Core.EF
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        protected ICoreDbContext context;
        public UnitOfWork(ICoreDbContext context)
        {
            this.context = context;
            if (this.context != null)
            {
                this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                this.context.ChangeTracker.AutoDetectChangesEnabled = false;
            }
        }

        public UnitOfWork(IDbContextFactory dbContextFactory)
        {
            context = dbContextFactory.Create();
            if (context != null)
            {
                context.ChangeTracker.AutoDetectChangesEnabled = false;
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            }
        }

        public ICatalogueRepository<T> CatalogueRepository<T>() where T : KTAppDomainCatalogue
        {
            return new CatalogueRepository<T>(context);
        }

        public abstract IDomainRepository<T> Repository<T>() where T : KTAppDomain;

        public void Save()
        {
            context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return context.SaveChanges(acceptAllChangesOnSuccess);
        }

        public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            return context.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
