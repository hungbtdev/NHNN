using AutoMapper;
using KTApps.AuthService.Entities;
using KTApps.AuthService.Interface;
using KTApps.Core.Services;

namespace KTApps.AuthService
{
    public class JobTitleService : CatalogueService<JobTitles>, IJobTitleService
    {
        public JobTitleService(IAuthUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
