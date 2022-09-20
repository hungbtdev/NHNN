using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.DTO
{
    public class CityDTO : CatalogueObjectDTO
    {
        public CityDTO()
        {
            Districts = new HashSet<DistrictDTO>();
        }

        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Profile_Resource.Country), ResourceType = typeof(Profile_Resource))]
        public Guid CountryId { get; set; }

        [Display(Name = nameof(Profile_Resource.GeoArea), ResourceType = typeof(Profile_Resource))]
        public Guid? GeoAreaId { get; set; }

        public CountryDTO Countries { get; set; }
        public GeoAreaDTO GeoAreas { get; set; }
        public ICollection<DistrictDTO> Districts { get; set; }

        public string CountryName
        {
            get
            {
                return Countries?.Name;
            }
        }
    }
}
