using System;
using System.ComponentModel.DataAnnotations;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.DTO
{
    public class WardDTO : CatalogueObjectDTO
    {
        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Profile_Resource.District), ResourceType = typeof(Profile_Resource))]
        public Guid DistrictId { get; set; }
        public DistrictDTO Districts { get; set; }

        public string DistrictName
        {
            get
            {
                return Districts?.Name;
            }
        }
    }
}
