using AutoMapper;
using KTApps.AuthService.Entities;
using KTApps.AuthService.Interface;
using KTApps.Core.Services;

namespace KTApps.AuthService
{
    public class AreaService : CatalogueService<Areas>, IAreaService
    {
        public AreaService(IAuthUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
