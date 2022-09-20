using KTApps.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTApps.AuthService.Entities
{
    [Table("UserGroups")]
    public class UserGroups : KTAppDomainCatalogue
    {
        public UserGroups()
        {
            UserInGroups = new List<UserInGroups>();
            PermitObjectPermissions = new List<PermitObjectPermissions>();
        }
        public IList<UserInGroups> UserInGroups { set; get; }
        public IList<PermitObjectPermissions> PermitObjectPermissions { set; get; }
    }
}
