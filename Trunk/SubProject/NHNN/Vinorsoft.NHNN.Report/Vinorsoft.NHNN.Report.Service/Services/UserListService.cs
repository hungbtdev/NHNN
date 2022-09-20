using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Vinorsoft.Core;
using Vinorsoft.NHNN.Report.Service.Entities;
using Vinorsoft.NHNN.Report.Service.Interface;

namespace Vinorsoft.NHNN.Report.Service
{
    public class UserListService : CoreService<UserList>, IUserListService
    {
        public UserListService(INHNNDbContext coreDbContext) : base(coreDbContext)
        {
        }

        public IList<UserViewList> GetUserView()
        {
            var userViewLists = coreDbContext.Query<UserViewList>().ToList();
            return userViewLists;
        }

        /// <summary>
        /// Lấy thông tin danh sách báo cáo tức thời
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="inside"></param>
        /// <returns></returns>
        public IList<UserViewDetail> GetUserViewDetail(DateTime? startDate, DateTime? endDate, bool inside)
        {
            IList<UserViewDetail> userViewDetails = new List<UserViewDetail>();
            var userViews = this.coreDbContext.Query<UserViewDetail>()
                .Where(e =>
                (!startDate.HasValue || e.CheckInOutTime >= startDate.Value)
                && (!endDate.HasValue || e.CheckInOutTime <= endDate.Value)
                //&& ((inside && e.InOutType > 0) || (!inside && e.InOutType == 0))
                )
                .Select(x => new UserViewDetail()
                {
                    EmployeeNumber = x.EmployeeNumber,
                    CheckInOutTime = x.CheckInOutTime,
                    InOutType = x.InOutType,
                    DeptName = x.DeptName,
                    ParentDeptName = x.ParentDeptName,
                    Door = x.Door,
                    JobtitleName = x.JobtitleName,
                    FullName = x.FullName,
                }).ToList();

            var userDetails = userViews
                .GroupBy(x => x.EmployeeNumber)
                .Select(x => new UserViewDetail()
                {
                    EmployeeNumber = x.Key,
                    FullName = x.FirstOrDefault().FullName,
                    ParentDeptName = x.FirstOrDefault().ParentDeptName,
                    DeptName = x.FirstOrDefault().DeptName,
                    JobtitleName = x.FirstOrDefault().JobtitleName,
                    Door = x.FirstOrDefault().Door,
                    CheckInOutTime = x.FirstOrDefault().CheckInOutTime,
                    UserViewDetails = x.ToList(),
                })
                .ToList();
            if (userDetails != null)
            {
                if (inside)
                {
                    foreach (var userDetail in userDetails)
                    {
                        if (!userDetail.UserViewDetails.Any(e => e.InOutType == 0))
                        {
                            userViewDetails.Add(userDetail);
                        }
                    }
                }
                else
                {
                    userViewDetails = userViews;
                }
            }
            userViewDetails = userViewDetails.OrderBy(x => x.CheckInOutTime).ToList();
            return userViewDetails;
        }


    }
}
