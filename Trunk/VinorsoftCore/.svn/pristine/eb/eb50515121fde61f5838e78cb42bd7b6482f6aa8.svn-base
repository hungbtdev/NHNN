using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Utils;

namespace Vinorsoft.Core.VDbContext.DataSeeder
{
    public class AuthDataSeeder
    {

        public static void Seed(DbContext dbContext)
        {
            dbContext.AddOrUpdateCate<Permissions>(CoreConstants.AddNew.ToString(), "Thêm mới");
            dbContext.AddOrUpdateCate<Permissions>(CoreConstants.Delete.ToString(), "Xóa");
            dbContext.AddOrUpdateCate<Permissions>(CoreConstants.Edit.ToString(), "Chỉnh sửa");
            dbContext.AddOrUpdateCate<Permissions>(CoreConstants.View.ToString(), "Xem");
            dbContext.AddOrUpdateCate<Permissions>(CoreConstants.Import.ToString(), "Import");
            dbContext.AddOrUpdateCate<Permissions>(CoreConstants.Export.ToString(), "Export");
            dbContext.AddOrUpdateCate<Permissions>(CoreConstants.Download.ToString(), "Download");
            dbContext.AddOrUpdateCate<Permissions>(CoreConstants.Print.ToString(), "In");
            dbContext.AddOrUpdateCate<Permissions>(CoreConstants.Copy.ToString(), "Copy");
            dbContext.AddOrUpdateCate<Permissions>(CoreConstants.Cancel.ToString(), "Cancel");
            dbContext.AddOrUpdateCate<Permissions>(CoreConstants.Upload.ToString(), "Upload");
            dbContext.AddOrUpdateCate<Permissions>(CoreConstants.Approve.ToString(), "Approve");

            //dbContext.AddOrUpdateCate<UserGroups>("Admin", "Admin");
            if (!dbContext.Set<Users>().Any(e => !e.Deleted && e.Username.Equals("admin", StringComparison.OrdinalIgnoreCase)))
            {
                var userId = Guid.Parse("0A0D1EB5-882A-4E88-B171-FF15CFE1E9DD");
                dbContext.Set<Users>().Add(new Users()
                {
                    Id = userId,
                    Username = "admin",
                    Password = SecurityUtils.HashSHA1("123456"),
                    FirstName = "Vinorsoft",
                    LastName = "Admin",
                    Phone = "(028)62715899",
                    Email = "support@vinorsoft.com",
                    Active = true,
                    Created = DateTime.Now,
                    CreatedBy = "system",
                    UserInGroups = new HashSet<UserInGroups>()
                    {
                        new UserInGroups()
                        {
                            Id = Guid.NewGuid(),
                            UserId = userId,
                            UserGroups = new UserGroups()
                            {
                                Id = Guid.NewGuid(),
                                Active = true,
                                Created = DateTime.Now,
                                CreatedBy = "system",
                                Code = "Admin",
                                Name = "Admin",
                            }
                        }
                    }
                });
            }

            dbContext.SaveChanges();
        }
    }
}
