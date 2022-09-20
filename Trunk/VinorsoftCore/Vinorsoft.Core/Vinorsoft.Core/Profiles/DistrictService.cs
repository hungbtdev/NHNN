
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core
{
    public class DistrictService : CoreCatalogueService<Districts>, IDistrictService
    {
        public DistrictService(IProfileDbContext dbContext) : base(dbContext)
        {
        }
    }
}
