using KTApps.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTApps.ProfileService.Entities
{
    public class ProfileRelatives : KTAppDomain
    {
        [Required]
        public bool IsAboard { set; get; }
        [ForeignKey("RelationTypes")]
        public Guid? RelationTypeId { set; get; }
        public CatRelationTypes RelationTypes { set; get; }

        [ForeignKey("Profiles")]
        public Guid ProfileId { set; get; }
        public Profiles Profiles { set; get; }

        [ForeignKey("Countries")]
        public Guid? CountryId { set; get; }
        public CatCountries Countries { set; get; }

        [MaxLength(1000)]
        public string FullName { set; get; }
        public int? YearOfBirth { set; get; }
        public DateTime? StartDate { set; get; }
        [MaxLength(1000)]
        public string Address { set; get; }
        [MaxLength(1000)]
        public string Purpose { set; get; }
    }
}