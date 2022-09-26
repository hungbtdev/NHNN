using System;
using System.Linq;
using Vinorsoft.Core;
using Vinorsoft.NHNN.Report.Service.Entities;
using Vinorsoft.NHNN.Report.Service.Interface;

namespace Vinorsoft.NHNN.Report.Service
{
    public class UserConfigService : CoreService<UserConfigs>, IUserConfigService
    {
        public UserConfigService(INHNNDbContext coreDbContext) : base(coreDbContext)
        {
        }

        public UserConfigs EnsureUserExist(int userId)
        {
            UserConfigs userConfig = new UserConfigs();
            //userConfig = coreDbContext.Set<UserConfigs>().FirstOrDefault(e => e.UserId == userId);
            //if (userConfig == null)
            //{
            //    userConfig = coreDbContext.Set<UserList>().Where(e => e.IdUser == userId).Select(e => new UserConfigs()
            //    {
            //        Id = Guid.NewGuid(),
            //        Active = true,
            //        CardId = e.IDNumber,
            //        Clot = e.Cuc,
            //        Created = DateTime.Now,
            //        Department = e.Phong,
            //        FirstName = e.FirstName,
            //        LastName = e.Name,
            //        JobTitle = e.ChucVu,
            //        IsNoCaculate = false,
            //        UserId = e.IdUser
            //    }).FirstOrDefault();
            //    if (userConfig != null)
            //    {
            //        coreDbContext.Set<UserConfigs>().Add(userConfig);
            //        coreDbContext.SaveChanges();
            //    }
            //}

            return userConfig;
        }

        /// <summary>
        /// Lấy thông tin cấu hình user
        /// </summary>
        /// <param name="employeeNumber"></param>
        /// <returns></returns>
        public UserConfigs GetUserConfigInfo(string employeeNumber)
        {
            UserConfigs userConfigs = null;
            userConfigs = this.coreDbContext.Set<UserConfigs>().Where(e => e.EmployeeNumber == employeeNumber).FirstOrDefault();
            return userConfigs;
        }

        public int UpdateIsNoCaculate(UserConfigs userConfig)
        {
            var exists = coreDbContext.Set<UserConfigs>().FirstOrDefault(e => e.EmployeeNumber == userConfig.EmployeeNumber);
            if (exists != null)
            {
                exists.Deleted = userConfig.Deleted;
                coreDbContext.Set<UserConfigs>().Update(exists);
                return coreDbContext.SaveChanges();
            }
            else
            {
                coreDbContext.Set<UserConfigs>().Add(userConfig);
                return coreDbContext.SaveChanges();
            }
        }
    }
}
