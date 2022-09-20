using System.Collections.Generic;
using Vinorsoft.Core.DTO;

namespace Vinorsoft.Core.DTO
{

    public class CountryDTO : CatalogueObjectDTO
    {
        public CountryDTO()
        {
            Cities = new HashSet<CityDTO>();
        }
    
        public ICollection<CityDTO> Cities { get; set; }
    }
}
