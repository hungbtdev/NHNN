using System;
using System.Threading;
using System.Threading.Tasks;
using Vinorsoft.Core.Command;
using Vinorsoft.Core.Domain.Comands;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Resx;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Interface;
using MediatR;
using Vinorsoft.Core.Notification.Commands;
using System.Linq;

namespace Vinorsoft.Core
{
    public class DeviceTokenCommandHandler : VBaseCommand<DeviceTokenDTO, DeviceTokens, IDeviceTokenService>, IRequestHandler<DeleteDeviceTokenCommands, bool>
    {
        public DeviceTokenCommandHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override Task<DeviceTokenDTO> Handle(CreateComand<DeviceTokenDTO> request, CancellationToken cancellationToken)
        {
            if (service.Any(e => e.RefId == request.Data.RefId && e.ExpoPushToken == request.Data.ExpoPushToken))
            {
                var device = service.Queryable.FirstOrDefault(e => e.ExpoPushToken == request.Data.ExpoPushToken && e.RefId == request.Data.RefId);
                if (device != null)
                {
                    device.Active = true;
                    var result = service.Update(device);
                    return Task.FromResult(request.Data);
                }
                else
                {
                    throw new Exception(string.Format(CoreErrorResource.ERROR_NOT_FOUND, "Device token"));
                }
            }
            return base.Handle(request, cancellationToken);
        }

        public override Task<DeviceTokenDTO> Handle(UpdateComand<DeviceTokenDTO> request, CancellationToken cancellationToken)
        {
            if (service.Any(e => e.RefId == request.Data.RefId && e.ExpoPushToken == request.Data.ExpoPushToken))
                throw new Exception(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, request.Data.ExpoPushToken));
            return base.Handle(request, cancellationToken);
        }

        public Task<bool> Handle(DeleteDeviceTokenCommands request, CancellationToken cancellationToken)
        {
            var device = service.Queryable.FirstOrDefault(e => e.ExpoPushToken == request.Token && e.RefId == request.UserId);
            if (device != null)
            {
                device.Active = false;
                var result = service.Update(device);
                return Task.FromResult(result > 0);
            }
            else
            {
                throw new Exception(string.Format(CoreErrorResource.ERROR_NOT_FOUND, "Device token"));
            }
        }
    }
}
