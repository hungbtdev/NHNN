using AutoMapper;
using KTApps.Core.Services;
using KTApps.ShareService.Entities;
using KTApps.ShareService.Interface;

namespace KTApps.ShareService
{
    public class CoreSystemConfigService : CatalogueService<CoreSystemConfigs>, ICoreSystemConfigService
    {
        public CoreSystemConfigService(ICoreConfigUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
