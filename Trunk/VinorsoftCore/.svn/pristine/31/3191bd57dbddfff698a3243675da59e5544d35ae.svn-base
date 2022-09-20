
namespace KTApps.ProfileService.Entities
{
    using KTApps.Domain;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// địa chỉ
    /// </summary>
    public class CatAddress : KTAppDomain
    {
        [Required]
        [MaxLength(1000)]
        public string Address { set; get; }

        [ForeignKey("Districts")]
        public Guid? DistrictId { set; get; }
        public CatDistricts Districts { set; get; }

        [ForeignKey("Wards")]
        public Guid? WardId { set; get; }
        public CatWards Wards { set; get; }

        [ForeignKey("Countries")]
        public Guid? CountryId { set; get; }
        public CatCountries Countries { set; get; }


        [ForeignKey("Cities")]
        public Guid? CityId { set; get; }
        public CatCities Cities { set; get; }
        
    }
}
