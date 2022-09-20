using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.DTO
{
    public class DistrictDTO : CatalogueObjectDTO
    {
        public DistrictDTO()
        {
            Wards = new HashSet<WardDTO>();
        }

        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Profile_Resource.City), ResourceType = typeof(Profile_Resource))]
        public Guid CityId { get; set; }

        public CityDTO Cities { get; set; }
        public ICollection<WardDTO> Wards { get; set; }

        public string CityName
        {
            get
            {
                return Cities?.Name;
            }
        }
    }
}
