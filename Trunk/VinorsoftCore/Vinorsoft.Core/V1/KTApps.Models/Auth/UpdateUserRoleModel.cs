using System;
using System.Collections.Generic;
using System.Text;

namespace KTApps.Models
{
    public class UpdateUserRoleModel
    {
        public UpdateUserRoleModel()
        {
            RoleIds = new List<Guid>();
        }
        public Guid UserId { set; get; }
        public IList<Guid> RoleIds { set; get; }
    }
}
