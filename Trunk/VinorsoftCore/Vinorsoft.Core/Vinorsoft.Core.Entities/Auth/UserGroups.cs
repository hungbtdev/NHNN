using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Vinorsoft.Core.Domain;

namespace Vinorsoft.Core.Entities
{
    public class UserGroups : VinorsoftCatalogueDomain
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
