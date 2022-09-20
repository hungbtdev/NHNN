using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Vinorsoft.Core.DTO;

namespace Vinorsoft.Core.DTO
{
    public class UserGroupDTO : CatalogueObjectDTO
    {
        public UserGroupDTO() : base()
        {
            UserInGroups = new List<UserInGroupDTO>();
            PermitObjectPermissions = new List<PermitObjectPermissionDTO>();
        }
        public IList<UserInGroupDTO> UserInGroups { set; get; }
        public IList<PermitObjectPermissionDTO> PermitObjectPermissions { set; get; }

        /// <summary>
        /// Nhận dữ liệu từ cây phân quyền
        /// </summary>
        public string SelectedPermissionJson { set; get; }

        public void ToValue()
        {
            if (!string.IsNullOrEmpty(SelectedPermissionJson))
            {
                PermitObjectPermissions = JsonConvert.DeserializeObject<IList<PermitObjectPermissionDTO>>(SelectedPermissionJson);
            }
        }

    }
}
