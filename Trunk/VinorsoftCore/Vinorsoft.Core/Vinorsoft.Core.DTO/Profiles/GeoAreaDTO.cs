using System.Collections.Generic;
using Vinorsoft.Core.DTO;

namespace Vinorsoft.Core.DTO
{
    public class GeoAreaDTO : CatalogueObjectDTO
    {
        public GeoAreaDTO()
        {
            Cities = new HashSet<CityDTO>();
        }
        public ICollection<CityDTO> Cities { get; set; }
    }
}
