using KTApps.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTApps.ProfileService.Entities
{
    public class ProfileWorkingHistories : KTAppDomain
    {
        public DateTime? StartDate { set; get; }
        public DateTime? EndDate { set; get; }

        [ForeignKey("Companies")]
        public Guid? CompanyId { set; get; }
        public CatCompanies Companies { set; get; }

        [ForeignKey("Majors")]
        public Guid? MajorId { set; get; }
        public CatMajors Majors { set; get; }

        [ForeignKey("Profiles")]
        public Guid ProfileId { set; get; }
        public Profiles Profiles { set; get; }

        [MaxLength(1000)]
        public string JobDetail { set; get; }
    }
}