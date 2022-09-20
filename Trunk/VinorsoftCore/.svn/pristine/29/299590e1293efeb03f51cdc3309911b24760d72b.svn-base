using System;
using System.ComponentModel.DataAnnotations.Schema;
using Vinorsoft.Core.Domain;

namespace Vinorsoft.Core.Entities
{
    [Table("Profiles")]
    public class Profiles : VinorsoftDomain
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [ForeignKey("Wards")]
        public Guid? WardId { get; set; }
        [ForeignKey("Districts")]
        public Guid? DistrictId { get; set; }
        [ForeignKey("Cities")]
        public Guid? CityId { get; set; }
        [ForeignKey("Countries")]
        public Guid? CountryId { get; set; }
        public string Description { get; set; }
        [ForeignKey("GeoAreas")]
        public Guid? GeoAreaId { get; set; }

        public Cities Cities { get; set; }
        public Countries Countries { get; set; }
        public Districts Districts { get; set; }
        public GeoAreas GeoAreas { get; set; }
        public Wards Wards { get; set; }
    }
}
