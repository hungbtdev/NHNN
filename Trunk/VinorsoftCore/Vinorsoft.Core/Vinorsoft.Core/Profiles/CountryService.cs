
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core
{
    public class CountryService : CoreCatalogueService<Countries>, ICountryService
    {
        public CountryService(IProfileDbContext dbContext) : base(dbContext)
        {
        }
    }
}
