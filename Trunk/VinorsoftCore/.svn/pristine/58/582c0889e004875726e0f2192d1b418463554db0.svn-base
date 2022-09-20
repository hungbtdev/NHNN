using KTApps.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTApps.ProfileService.Entities
{
    [Table("Profiles")]
    public class Profiles : KTAppDomain
    {
        public Profiles()
        {
            ProfileAddress = new List<ProfileAddress>();
            ProfilePhones = new List<ProfilePhones>();
            ProfileWorkingHistories = new List<ProfileWorkingHistories>();
            ProfileIdentications = new List<ProfileIdentications>();
            ProfileEducationHistories = new List<ProfileEducationHistories>();
            ProfileDegrees = new List<ProfileDegrees>();
            ProfileRelatives = new List<ProfileRelatives>();
        }

        #region Properties
        [ForeignKey("NativeLanguages")]
        public Guid? NativeLanguageId { set; get; }
        public CatLanguages NativeLanguages { set; get; }

        [ForeignKey("Genders")]
        public Guid? GenderId { set; get; }
        public CatGenders Genders { set; get; }

        public Guid? AvatarId { set; get; }

        [ForeignKey("MaritalStatus")]
        public Guid? MaritalStatusId { set; get; }
        public CatMaritalStatus MaritalStatus { set; get; }

        [ForeignKey("Religions")]
        public Guid? ReligionId { set; get; }
        public CatReligions Religions { set; get; }

        [Required]
        [MaxLength(255)]
        public string FirstName { set; get; }
        [Required]
        [MaxLength(255)]
        public string LastName { set; get; }

        public DateTime? BirthDate { set; get; }
        [MaxLength(1000)]
        public string BirthPlace { set; get; }

        [ForeignKey("EducationLevels")]
        public Guid? EducationLevelId { set; get; }
        public CatEducationLevels EducationLevels { set; get; }

        [ForeignKey("EducationStatus")]
        public Guid? EducationStatusId { set; get; }
        public CatEducationStatus EducationStatus { set; get; }

        [ForeignKey("Majors")]
        public Guid? MajorId { set; get; }
        public CatMajors Majors { set; get; }

        public DateTime? GraduationDate { set; get; }

        [MaxLength(1000)]
        public string Email { set; get; }
        [MaxLength(1000)]
        public string EvaluateYourseft { set; get; }
        [MaxLength(1000)]
        public string Hobies { set; get; }
        [MaxLength(1000)]
        public string Others { set; get; }
        [MaxLength(1000)]
        public string SpecialSkill { set; get; }

        [ForeignKey("ProfileHealths")]
        public Guid? ProfileHealthId { set; get; }

        #endregion

        public IList<ProfileAddress> ProfileAddress { set; get; }
        public IList<ProfilePhones> ProfilePhones { set; get; }
        public IList<ProfileWorkingHistories> ProfileWorkingHistories { set; get; }
        public IList<ProfileRelatives> ProfileRelatives { set; get; }
        public IList<ProfileIdentications> ProfileIdentications { set; get; }
        public IList<ProfileEducationHistories> ProfileEducationHistories { set; get; }
        public IList<ProfileDegrees> ProfileDegrees { set; get; }
        public ProfileHealths ProfileHealths { set; get; }
    }
}
