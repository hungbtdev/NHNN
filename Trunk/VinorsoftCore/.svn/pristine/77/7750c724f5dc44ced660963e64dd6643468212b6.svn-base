using KTApps.Core.EF;
using KTApps.ShareService.Interface;
using KTApps.ShareService.Repository;

namespace KTApps.ShareService
{
    public class CoreUploadUnitOfWork : UnitOfWork, ICoreUploadUnitOfWork
    {
        public CoreUploadUnitOfWork(ICoreUploadDbContext context) : base(context)
        {
        }
        

        public override IDomainRepository<T> Repository<T>()
        {
            return new CoreUploadRepository<T>((ICoreUploadDbContext)context);
        }
    }
}
