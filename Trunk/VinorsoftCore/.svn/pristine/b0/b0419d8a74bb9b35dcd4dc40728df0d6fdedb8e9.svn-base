using KTApps.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KTApps.AuthService.Entities
{
    [Table("Users")]
    public class Users : KTAppDomain
    {
        public Users()
        {
            UserInGroups = new HashSet<UserInGroups>();
            UserDepartments = new HashSet<UserDepartments>();
            UserGroupIds = new List<string>();
        }

        [MaxLength(128)]
        [Required]
        public string Username { get; set; }
        [MaxLength(4000)]
        [Required]
        public string Password { get; set; }
        [DefaultValue(false)]
        [Required]
        public bool Locked { get; set; }
        [Required]
        public int FailedCount { get; set; }

        [MaxLength(1000)]
        public string FirstName { get; set; }
        [MaxLength(1000)]
        public string LastName { get; set; }
        [MaxLength(1000)]
        public string Phone { get; set; }
        [MaxLength(1000)]
        public string Email { get; set; }
        public DateTime? LockedEnd { get; set; }

        [ForeignKey("UserStatus")]
        public Guid? StatusId { set; get; }
        public UserStatus UserStatus { set; get; }

        [NotMapped]
        public IList<string> UserGroupIds { get; set; }
        public ICollection<UserInGroups> UserInGroups { get; set; }
        public ICollection<UserDepartments> UserDepartments { get; set; }
    }
}
