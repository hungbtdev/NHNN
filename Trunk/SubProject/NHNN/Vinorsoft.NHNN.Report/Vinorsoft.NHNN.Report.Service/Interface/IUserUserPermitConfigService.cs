using System;
using System.Collections;
using System.Collections.Generic;
using Vinorsoft.Core;
using Vinorsoft.Core.Interface;
using Vinorsoft.NHNN.Report.Service.Entities;

namespace Vinorsoft.NHNN.Report.Service.Interface
{
    public interface IUserUserPermitConfigService : ICoreService<UserPermitConfigs>
    {
        IList<string> HasPermitPb(Guid userId);
        IList<int> HasPermitGate(Guid userId);
    }
}
