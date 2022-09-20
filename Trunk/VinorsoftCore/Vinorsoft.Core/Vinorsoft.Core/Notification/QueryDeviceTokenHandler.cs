using System;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Query;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core
{
    public class QueryDeviceTokenHandler : CoreVQueryHandler<DeviceTokenDTO, DeviceTokens, IDeviceTokenService>
    {
        public QueryDeviceTokenHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
