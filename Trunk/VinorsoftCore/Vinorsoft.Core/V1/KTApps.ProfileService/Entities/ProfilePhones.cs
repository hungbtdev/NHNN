using KTApps.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTApps.ProfileService.Entities
{
    public class ProfilePhones : KTAppDomain
    {
        [ForeignKey("PhoneTypes")]
        public Guid? PhoneTypeId { set; get; }
        [ForeignKey("Profiles")]
        [Required]
        public Guid ProfileId { set; get; }
        [MaxLength(50)]
        public string PhoneNumber { set; get; }
        [MaxLength(1000)]
        public string Description { set; get; }

        public Profiles Profiles { set; get; }
        public CatPhoneTypes PhoneTypes { set; get; }
    }
}