using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vinorsoft.Core.App.Controllers;
using Vinorsoft.Core.Domain.Comands;
using Vinorsoft.Core.DTO;

namespace Vinorsoft.Core.NotiApp
{
    public abstract class ShareDeviceApiController : CQRSCoreController<DeviceTokenDTO>
    {
        public ShareDeviceApiController(IMediator mediator, IServiceProvider serviceProvider, IMapper mapper) : base(mediator, serviceProvider, mapper)
        {
        }


        [HttpPost]
        public async Task<object> NewDevice(DeviceTokenDTO deviceToken)
        {
            try
            {
                var result = await mediator.Send(new CreateComand<DeviceTokenDTO>(deviceToken));
                if (result != null)
                {
                    return new
                    {
                        Success = true,
                    };
                }

                return new
                {
                    Success = false
                };
            }
            catch (Exception ex)
            {
                HandleError(ex);
                return new
                {
                    Success = false
                };
            }
        }

        [NonAction]
        [HttpPost]
        public override Task<IActionResult> InsertAsync(string values)
        {
            return base.InsertAsync(values);
        }

        [NonAction]
        [HttpPost]
        public override Task<IActionResult> UpdateAsync(Guid key, string values)
        {
            return base.UpdateAsync(key, values);
        }

        [NonAction]
        [HttpPost]
        public override Task DeleteAsync(Guid key)
        {
            return base.DeleteAsync(key);
        }

    }
}