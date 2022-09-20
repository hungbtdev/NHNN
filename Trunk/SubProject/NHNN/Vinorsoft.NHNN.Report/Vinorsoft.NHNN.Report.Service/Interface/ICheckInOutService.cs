using System.Collections.Generic;
using System.Linq;
using Vinorsoft.Core;
using Vinorsoft.Core.Interface;
using Vinorsoft.NHNN.Report.Service.Entities;

namespace Vinorsoft.NHNN.Report.Service.Interface
{
    public interface ICheckInOutService
    {
        IQueryable<VwLogAccess> GetVwLogAccesses();
        IList<UserViewDetail> GetUserViewHistory(string employeeNumber);
    }
}
