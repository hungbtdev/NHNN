using KTApps.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTApps.ProfileService.Entities
{
    public class ProfileDegrees : KTAppDomain
    {
        [ForeignKey("DegreeTypes")]
        public Guid? DegreeTypeId { set; get; }
        [ForeignKey("Profiles")]
        [Required]
        public Guid ProfileId { set; get; }
        public DateTime? IssuedDate { set; get; }
        [MaxLength(255)]
        public string IssuedPlace { set; get; }
        [ForeignKey("Majors")]
        public Guid? MajorId { set; get; }
        public DateTime? StartDate { set; get; }
        public DateTime? EndDate { set; get; }
        [MaxLength(50)]
        [Required]
        public string Code { get; set; }
        public Profiles Profiles { set; get; }
        public CatDegreeTypes DegreeTypes { set; get; }
        public CatMajors Majors { set; get; }
    }
}