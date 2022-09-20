using Vinorsoft.Core;
using Vinorsoft.Core.Interface;
using Vinorsoft.NHNN.Report.Service.Entities;

namespace Vinorsoft.NHNN.Report.Service.Interface
{
    public interface IUserConfigService : ICoreService<UserConfigs>
    {
        UserConfigs EnsureUserExist(int id);
        int UpdateIsNoCaculate(UserConfigs userConfig);
        UserConfigs GetUserConfigInfo(string employeeNumber);
    }
}
