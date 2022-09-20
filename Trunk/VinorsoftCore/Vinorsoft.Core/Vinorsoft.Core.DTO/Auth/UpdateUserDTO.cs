using System;
using System.Linq;

namespace Vinorsoft.Core.DTO
{
    public class UpdateUserDTO : UserDTO
    {
        public new string Password { get; set; }

        public void ToValue()
        {
            if (UserGroupIds.Count > 0)
            {
                UserInGroups = UserGroupIds.Select(e => new UserInGroupDTO()
                {
                    Created = DateTime.Now,
                    Id = Guid.NewGuid(),
                    CreatedBy = CreatedBy,
                    GroupId = e,
                    Updated = DateTime.Now,
                    UserId = Id
                }).ToList();
            }
        }
    }
}
