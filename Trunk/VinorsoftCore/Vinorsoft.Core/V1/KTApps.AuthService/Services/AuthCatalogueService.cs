using AutoMapper;
using KTApps.Core.Interface;
using KTApps.Core.Services;
using KTApps.Domain;
using KTApps.AuthService.Interface;

namespace KTApps.AuthService
{
    public class AuthCatalogueService<E> : CatalogueService<E>, IAuthCatalogueService<E> where E : KTAppDomainCatalogue, new()
    {
        public AuthCatalogueService(IAuthUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
