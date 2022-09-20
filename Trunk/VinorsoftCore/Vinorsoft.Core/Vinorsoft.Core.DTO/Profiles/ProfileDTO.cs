using System;
using System.ComponentModel.DataAnnotations;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.DTO
{
    public class ProfileDTO : DomainObjectDTO
    {
        [StringLength(maximumLength: 255, MinimumLength = 0, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Profile_Resource.FirstName), ResourceType = typeof(Profile_Resource))]
        public string FirstName { get; set; }

        [StringLength(maximumLength: 255, MinimumLength = 0, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Profile_Resource.LastName), ResourceType = typeof(Profile_Resource))]
        public string LastName { get; set; }

        [Display(Name = nameof(Profile_Resource.BirthDate), ResourceType = typeof(Profile_Resource))]
        public DateTime? BirthDate { get; set; }

        [Display(Name = nameof(Profile_Resource.Phone), ResourceType = typeof(Profile_Resource))]
        [StringLength(maximumLength: 11, MinimumLength = 0, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public string Phone { get; set; }

        [Display(Name = nameof(Profile_Resource.Email), ResourceType = typeof(Profile_Resource))]
        [StringLength(maximumLength: 255, MinimumLength = 0, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public string Email { get; set; }

        [Display(Name = nameof(Profile_Resource.Ward), ResourceType = typeof(Profile_Resource))]
        public Guid? WardId { get; set; }

        [Display(Name = nameof(Profile_Resource.Address), ResourceType = typeof(Profile_Resource))]
        public string Address { get; set; }

        [Display(Name = nameof(Profile_Resource.District), ResourceType = typeof(Profile_Resource))]
        public Guid? DistrictId { get; set; }

        [Display(Name = nameof(Profile_Resource.City), ResourceType = typeof(Profile_Resource))]
        public Guid? CityId { get; set; }

        [Display(Name = nameof(Profile_Resource.Country), ResourceType = typeof(Profile_Resource))]
        public Guid? CountryId { get; set; }

        [Display(Name = nameof(Profile_Resource.Description), ResourceType = typeof(Profile_Resource))]
        public string Description { get; set; }

        [Display(Name = nameof(Profile_Resource.GeoArea), ResourceType = typeof(Profile_Resource))]
        public Guid? GeoAreaId { get; set; }

        [Display(Name = nameof(Profile_Resource.City), ResourceType = typeof(Profile_Resource))]
        public CityDTO Cities { get; set; }

        [Display(Name = nameof(Profile_Resource.Country), ResourceType = typeof(Profile_Resource))]
        public CountryDTO Countries { get; set; }

        [Display(Name = nameof(Profile_Resource.District), ResourceType = typeof(Profile_Resource))]
        public DistrictDTO Districts { get; set; }

        [Display(Name = nameof(Profile_Resource.GeoArea), ResourceType = typeof(Profile_Resource))]
        public GeoAreaDTO GeoAreas { get; set; }

        [Display(Name = nameof(Profile_Resource.Ward), ResourceType = typeof(Profile_Resource))]
        public WardDTO Wards { get; set; }

        [Display(Name = nameof(Profile_Resource.FullName), ResourceType = typeof(Profile_Resource))]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

    }
}
