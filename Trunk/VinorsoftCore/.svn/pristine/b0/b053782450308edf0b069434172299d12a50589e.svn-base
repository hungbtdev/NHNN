using KTApps.Core.EF;
using KTApps.Core.Factory;
using KTApps.Domain;
using KTApps.ShareService.Interface;

namespace KTApps.ShareService.Repository
{
    public class CoreConfigRepository<T> : DomainRepository<T>, ICoreConfigRepository<T> where T : KTAppDomain
    {
        public CoreConfigRepository(ICoreDbContext context) : base(context)
        {
        }

        public CoreConfigRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
