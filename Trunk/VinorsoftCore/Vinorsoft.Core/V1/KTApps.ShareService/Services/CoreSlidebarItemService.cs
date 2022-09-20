using AutoMapper;
using KTApps.Core.Services;
using KTApps.ShareService.Entities;
using KTApps.ShareService.Interface;

namespace KTApps.ShareService
{
    public class CoreSlidebarItemService : CatalogueService<CoreSlidebarItems>, ICoreSlidebarItemService
    {
        public CoreSlidebarItemService(ICoreConfigUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
