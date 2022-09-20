using KTApps.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTApps.ProfileService.Entities
{
    public class ProfileEducationHistories : KTAppDomain
    {
        [ForeignKey("EducationLevels")]
        public Guid? EducationLevelId { set; get; }
        public CatEducationLevels EducationLevels { set; get; }

        [ForeignKey("EducationStatus")]
        public Guid? EducationStatusId { set; get; }
        public CatEducationStatus EducationStatus { set; get; }

        [ForeignKey("Schools")]
        public Guid? SchoolId { set; get; }
        public CatSchools Schools { set; get; }

        public DateTime? StartDate { set; get; }
        public DateTime? EndDate { set; get; }

        [ForeignKey("Profiles")]
        [Required]
        public Guid ProfileId { set; get; }
        public Profiles Profiles { set; get; }
    }
}