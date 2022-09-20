using System;
using System.Collections.Generic;
using Vinorsoft.Core;
using Vinorsoft.Core.Interface;
using Vinorsoft.NHNN.Report.Service.Entities;

namespace Vinorsoft.NHNN.Report.Service.Interface
{
    public interface IUserListService : ICoreService<UserList>
    {
        IList<UserViewList> GetUserView();
        IList<UserViewDetail> GetUserViewDetail(DateTime? startDate, DateTime? endDate, bool inside);
    }
}
