
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core
{
    public class CityService : CoreCatalogueService<Cities>, ICityService
    {
        public CityService(IProfileDbContext dbContext) : base(dbContext)
        {

        }
    }
}
