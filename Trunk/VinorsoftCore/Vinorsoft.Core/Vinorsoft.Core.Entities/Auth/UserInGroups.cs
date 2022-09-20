using System;
using System.ComponentModel.DataAnnotations.Schema;
using Vinorsoft.Core.Domain;

namespace Vinorsoft.Core.Entities
{
    public class UserInGroups : VinorsoftDomain
    {
        [ForeignKey("Users")]
        public Guid UserId { set; get; }
        [ForeignKey("UserGroups")]
        public Guid GroupId { set; get; }

        public Users Users { set; get; }
        public UserGroups UserGroups { set; get; }
    }
}
