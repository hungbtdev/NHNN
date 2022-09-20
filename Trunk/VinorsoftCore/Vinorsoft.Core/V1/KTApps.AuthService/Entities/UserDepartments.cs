using KTApps.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KTApps.AuthService.Entities
{
    public class UserDepartments : KTAppDomain
    {
        [Required]
        [ForeignKey("Departments")]
        public Guid DepartmentId { set; get; }
        [Required]
        [ForeignKey("Users")]
        public Guid UserId { set; get; }
        [Required]
        [ForeignKey("JobTitles")]
        public Guid JobTitleId { set; get; }

        public Guid? Department2Id { get; set; }
        public Guid? Department3Id { get; set; }
        public Guid? Department4Id { get; set; }
        public Guid? Department5Id { get; set; }

        public Departments Departments { set; get; }
        public Users Users { set; get; }
        public JobTitles JobTitles { set; get; }
    }
}
