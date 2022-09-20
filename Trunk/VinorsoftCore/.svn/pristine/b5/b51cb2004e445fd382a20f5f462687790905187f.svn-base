using KTApps.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTApps.ProfileService.Entities
{
    public class ProfileAddress : KTAppDomain
    {
        [Required]
        [ForeignKey("Profiles")]
        public Guid ProfileId { set; get; }
        [Required]
        [ForeignKey("AddressTypes")]
        public Guid AddressTypeId { set; get; }
        [Required]
        [ForeignKey("Address")]
        public Guid AddressId { set; get; }

        public Profiles Profiles { set; get; }
        public CatAddressTypes AddressTypes { set; get; }
        public CatAddress Address { set; get; }
    }
}