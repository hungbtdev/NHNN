using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vinorsoft.Core.Domain;

namespace Vinorsoft.Core.Entities
{
    public class Users : VinorsoftDomain
    {
        public Users()
        {
            UserInGroups = new HashSet<UserInGroups>();
            UserGroupIds = new List<Guid>();
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
        public Guid? ProfileId { set; get; }

        [NotMapped]
        public IList<Guid> UserGroupIds { get; set; }
        public ICollection<UserInGroups> UserInGroups { get; set; }
    }
}
