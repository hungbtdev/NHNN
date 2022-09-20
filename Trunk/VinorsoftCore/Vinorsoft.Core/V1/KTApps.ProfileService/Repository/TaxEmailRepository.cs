using KTApps.Core.EF;
using KTApps.Domain;
using KTApps.ProfileService.Interface;

namespace KTApps.ProfileService.Repository
{
    public class TaxEmailRepository<T> : DomainRepository<T>, ICoreProfileRepository<T> where T : KTAppDomain
    {
        public TaxEmailRepository(ICoreProfileDbContext context) : base(context)
        {

        }
    }
}
