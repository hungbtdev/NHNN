using AutoMapper;
using KTApps.Core.Services;
using KTApps.Domain;
using KTApps.ProfileService.Interface;

namespace KTApps.ProfileService
{
    public class CoreProfileCatalogueService<E> : CatalogueService<E>, ICoreProfileCatalogueService<E> where E : KTAppDomainCatalogue, new()
    {
        public CoreProfileCatalogueService(ICoreProfileUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
