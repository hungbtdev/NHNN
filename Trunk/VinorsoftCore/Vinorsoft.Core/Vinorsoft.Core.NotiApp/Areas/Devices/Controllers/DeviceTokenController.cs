using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vinorsoft.Core.App.Attribute;
using Vinorsoft.Core.App.Controllers;
using Vinorsoft.Core.DTO;

namespace Vinorsoft.Core.NotiApp.Areas.Template.Controllers
{
    [Area("Devices")]
    [VinorsoftAuthorize2(permission: new string[] { CoreConstants.View })]
    public class DeviceTokenController : CQRSCoreController<DeviceTokenDTO>
    {
        public DeviceTokenController(IMediator mediator, IServiceProvider serviceProvider, IMapper mapper) : base(mediator, serviceProvider, mapper)
        {
        }

        [HttpGet]
        public virtual IActionResult Index()
        {
            return View();
        }
        
        [NonAction]
        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.AddNew })]
        [HttpGet]
        public virtual IActionResult NewItem()
        {
            return null;
        }

        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.AddNew })]
        [ActionName("NewItem")]
        [NonAction]
        [HttpPost]
        public virtual IActionResult NewItem(DeviceTokenDTO newItem)
        {
            return null;
        }

        [HttpGet]
        [NonAction]
        public virtual IActionResult UpdateItem(Guid id)
        {
            return null;
        }

        [HttpPost]
        [NonAction]
        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.Edit })]
        [ActionName("UpdateItem")]
        public virtual IActionResult UpdateItem(DeviceTokenDTO updateItem)
        {
            return null;
        }
    }
}