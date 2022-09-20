
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core
{
    public class CoreSlidebarItemService : CoreCatalogueService<CoreSlidebarItems>, ICoreSlidebarItemService
    {
        public CoreSlidebarItemService(ICoreConfigDbContext coreDbContext) : base(coreDbContext)
        {
        }
    }
}
