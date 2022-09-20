using AutoMapper;
using KTApps.Core.Services;
using KTApps.ProfileService.Entities;
using KTApps.ProfileService.Interface;

namespace KTApps.ProfileService
{
    public class ProfileEducationHistoryService : DomainService<ProfileEducationHistories>, IProfileEducationHistoryService
    {
        public ProfileEducationHistoryService(ICoreProfileUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
