using KTApps.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTApps.ProfileService.Entities
{
    public class ProfileIdentications : KTAppDomain
    {
        [ForeignKey("Profiles")]
        [Required]
        public Guid ProfileId { set; get; }
        [ForeignKey("IdentificationTypes")]
        [Required]
        public Guid? IdentificationTypeId { set; get; }
        [MaxLength(100)]
        public string Code { set; get; }
        public DateTime? IssuedDate { set; get; }
        [MaxLength(1000)]
        public string IssuedPlace { set; get; }

        public Profiles Profiles { set; get; }
        public CatIdentificationTypes IdentificationTypes { set; get; }
    }
}