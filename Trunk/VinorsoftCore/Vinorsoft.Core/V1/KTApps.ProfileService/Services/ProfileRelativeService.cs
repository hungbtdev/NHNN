using AutoMapper;
using KTApps.Core.Services;
using KTApps.ProfileService.Entities;
using KTApps.ProfileService.Interface;

namespace KTApps.ProfileService
{
    public class ProfileRelativeService : DomainService<ProfileRelatives>, IProfileRelativeService
    {
        public ProfileRelativeService(ICoreProfileUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
