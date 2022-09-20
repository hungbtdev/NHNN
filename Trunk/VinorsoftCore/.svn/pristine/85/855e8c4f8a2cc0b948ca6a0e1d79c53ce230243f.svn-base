using KTApps.Core.EF;
using KTApps.ProfileService.Interface;
using KTApps.ProfileService.Repository;

namespace KTApps.ProfileService
{
    public class CoreProfileUnitOfWork : UnitOfWork, ICoreProfileUnitOfWork
    {
        readonly ICoreProfileDbContext coreProfileDbContext;
        public CoreProfileUnitOfWork(ICoreProfileDbContext coreProfileDbContext) : base(coreProfileDbContext)
        {
            this.coreProfileDbContext = coreProfileDbContext;
        }
        public override IDomainRepository<T> Repository<T>()
        {
            return new TaxEmailRepository<T>(coreProfileDbContext);
        }
    }
}
