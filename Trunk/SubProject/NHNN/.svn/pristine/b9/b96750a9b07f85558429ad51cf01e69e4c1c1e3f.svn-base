using System.Collections.Generic;
using System.Linq;
using Vinorsoft.Core;
using Vinorsoft.NHNN.Report.Service.Entities;
using Vinorsoft.NHNN.Report.Service.Interface;

namespace Vinorsoft.NHNN.Report.Service
{
    public class CheckInOutService :  ICheckInOutService
    {
        public INHNNDbContext coreDbContext;
        public CheckInOutService(INHNNDbContext coreDbContext) 
        {
            this.coreDbContext = coreDbContext;
        }
        public IQueryable<VwLogAccess> GetVwLogAccesses()
        {
            return coreDbContext.Query<VwLogAccess>().AsQueryable();
        }
      

        /// <summary>
        /// Lấy thông tin lịch sử ra vào của nhân viên
        /// </summary>
        /// <param name="employeeNumber"></param>
        /// <returns></returns>
        public IList<UserViewDetail> GetUserViewHistory(string employeeNumber)
        {
            IList<UserViewDetail> userViewDetails = new List<UserViewDetail>();
            userViewDetails = this.coreDbContext.Query<UserViewDetail>()
                .Where(e => e.EmployeeNumber == employeeNumber)
                .OrderBy(x => x.CheckInOutTime).ToList();
            return userViewDetails;
        }
    }
}
