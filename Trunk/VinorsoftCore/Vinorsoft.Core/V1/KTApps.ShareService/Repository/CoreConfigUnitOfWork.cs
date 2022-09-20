using KTApps.Core.EF;
using KTApps.Core.Factory;
using KTApps.ShareService.Interface;
using KTApps.ShareService.Repository;

namespace KTApps.ShareService
{
    public class CoreConfigUnitOfWork : UnitOfWork, ICoreConfigUnitOfWork
    {
        //public CoreConfigUnitOfWork(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        //{
        //}

        public CoreConfigUnitOfWork(ICoreConfigDbContext context) : base(context)
        {
        }

        public override IDomainRepository<T> Repository<T>()
        {
            return new CoreConfigRepository<T>(context);
        }
    }
}
