using KTApps.Core.Interface;
using KTApps.Domain;

namespace KTApps.AuthService.Interface
{
    public interface IAuthCatalogueService<T> : ICatalogueService<T> where T : KTAppDomainCatalogue
    {

    }
}
