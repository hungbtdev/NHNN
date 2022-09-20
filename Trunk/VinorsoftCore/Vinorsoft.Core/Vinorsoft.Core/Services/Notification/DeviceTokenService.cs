using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core
{
    public class DeviceTokenService : CoreService<DeviceTokens>, IDeviceTokenService
    {
        public DeviceTokenService(INotificationDbContext coreDbContext) : base(coreDbContext)
        {
        }
    }
}
