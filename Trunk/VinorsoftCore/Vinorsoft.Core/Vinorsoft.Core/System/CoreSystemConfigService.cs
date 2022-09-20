
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core
{
    public class CoreSystemConfigService : CoreCatalogueService<CoreSystemConfigs>, ICoreSystemConfigService
    {
        public CoreSystemConfigService(ICoreConfigDbContext coreDbContext) : base(coreDbContext)
        {
        }
    }
}
