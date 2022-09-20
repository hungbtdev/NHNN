using AutoMapper;
using KTApps.AuthService.Entities;
using KTApps.AuthService.Interface;
using KTApps.Core.Factory;
using KTApps.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace KTApps.AuthService
{
    public class UserGroupService : CatalogueService<UserGroups>, IUserGroupService
    {
        private readonly IAuthUnitOfWork authUnitOfWork;

        public UserGroupService(IAuthUnitOfWork authUnitOfWork, IMapper mapper) : base(authUnitOfWork, mapper)
        {
            this.authUnitOfWork = authUnitOfWork;
        }

        public override bool Save(UserGroups item)
        {
            var existUserGroups = authUnitOfWork.Repository<UserGroups>()
               .GetQueryable()
               .FirstOrDefault(e => e.Id == item.Id);
            if (existUserGroups != null)
            {
                var existsUserInGroups = authUnitOfWork.Repository<UserInGroups>()
                  .GetQueryable()
                  .AsNoTracking()
                  .Where(e => e.GroupId == item.Id)
                  .ToList();

                foreach (UserInGroups userInGroup in item.UserInGroups)
                {
                    // List mới đẩy lên nếu không có trong db thì tạo mới
                    var exists = authUnitOfWork.Repository<UserInGroups>().GetQueryable()
                        .FirstOrDefault(e => e.GroupId == userInGroup.GroupId && e.UserId == userInGroup.UserId && !e.Deleted);
                    if (exists == null)
                    {
                        authUnitOfWork.Repository<UserInGroups>().Create(userInGroup);
                    }
                    else if (userInGroup.Deleted)
                    {
                        authUnitOfWork.Repository<UserInGroups>().Delete(exists);
                    }
                }

                var permitObjects = authUnitOfWork.Repository<PermitObjectPermissions>()
                 .GetQueryable()
                 .AsNoTracking()
                 .Where(e => e.GroupId == item.Id)
                 .ToList();

                foreach (PermitObjectPermissions permitObject in permitObjects)
                {
                    string sql = "Delete from PermitObjectPermissions where GroupId = @GroupId and PermitObjectId =@PermitObjectId";
                    authUnitOfWork.Repository<PermitObjectPermissions>().ExecuteNonQuery(sql,
                                            new Dictionary<string, object>()
                                            {
                                                {"@GroupId",permitObject.GroupId},
                                                {"@PermitObjectId",permitObject.PermitObjectId},
                                            });
                }

                foreach (PermitObjectPermissions permitObject in item.PermitObjectPermissions)
                {
                    authUnitOfWork.Repository<PermitObjectPermissions>().AddOrUpdate(permitObject);
                }

                item.PermitObjectPermissions = null;
                item.UserInGroups = null;
                existUserGroups = mapper.Map<UserGroups>(item);
                authUnitOfWork.Repository<UserGroups>().Update(existUserGroups);
            }
            else
            {
                authUnitOfWork.Repository<UserGroups>().Create(item);
            }

            authUnitOfWork.Save();
            return true;
        }

        public override UserGroups GetById(Guid id)
        {
            return authUnitOfWork.Repository<UserGroups>()
                .GetQueryable()
                .Where(e => e.Id == id)
                .Select(e => new UserGroups()
                {
                    Active = e.Active,
                    AutoGenerateCode = false,
                    Code = e.Code,
                    Name = e.Name,
                    Created = e.Created,
                    CreatedBy = e.CreatedBy,
                    Deleted = e.Deleted,
                    Description = e.Description,
                    Id = e.Id,
                    Updated = e.Updated,
                    UpdatedBy = e.UpdatedBy,
                    PermitObjectPermissions = e.PermitObjectPermissions.Where(s => !s.Deleted)
                    .ToList(),
                    UserInGroups = e.UserInGroups.Select(u => new UserInGroups()
                    {
                        Active = u.Active,
                        Created = u.Created,
                        CreatedBy = u.CreatedBy,
                        Deleted = u.Deleted,
                        Id = u.Id,
                        Updated = u.Updated,
                        UpdatedBy = u.UpdatedBy,
                        Users = new Users()
                        {
                            Id = u.UserId,
                            Username = u.Users.Username,
                            FirstName = u.Users.FirstName,
                            LastName = u.Users.LastName
                        },
                        GroupId = u.GroupId,
                        UserId = u.UserId
                    }).ToList()
                }).AsNoTracking()
                .FirstOrDefault();
        }

    }
}
