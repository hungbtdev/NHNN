using AutoMapper;
using KTApps.Core.Services;
using KTApps.ProfileService.Entities;
using KTApps.ProfileService.Interface;

namespace KTApps.ProfileService
{
    public class ProfileHealthService : DomainService<ProfileHealths>, IProfileHealthService
    {
        public ProfileHealthService(ICoreProfileUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
