
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core
{
    public class CorePageTitleService : CoreCatalogueService<CorePageTitles>, ICorePageTitleService
    {
        public CorePageTitleService(ICoreConfigDbContext coreDbContext) : base(coreDbContext)
        {
        }
    }
}
