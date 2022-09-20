using KTApps.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KTApps.AuthService.Entities
{
    [Table("UserInGroups")]
    public class UserInGroups : KTAppDomain
    {
        [ForeignKey("Users")]
        public Guid UserId { set; get; }
        [ForeignKey("UserGroups")]
        public Guid GroupId { set; get; }

        public Users Users { set; get; }
        public UserGroups UserGroups { set; get; }
    }
}
