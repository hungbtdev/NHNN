using AutoMapper;
using KTApps.Core.Services;
using KTApps.ProfileService.Entities;
using KTApps.ProfileService.Interface;

namespace KTApps.ProfileService
{
    public class ProfileIdenticationService : DomainService<ProfileIdentications>, IProfileIdenticationService
    {
        public ProfileIdenticationService(ICoreProfileUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
