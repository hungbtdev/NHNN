using AutoMapper;
using KTApps.Core.Services;
using KTApps.ProfileService.Entities;
using KTApps.ProfileService.Interface;

namespace KTApps.ProfileService
{
    public class CoreAddressService : DomainService<CatAddress>, ICoreAddressService
    {
        public CoreAddressService(ICoreProfileUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
