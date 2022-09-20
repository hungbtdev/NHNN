using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vinorsoft.Core.App.Attribute;
using Vinorsoft.Core.DTO;

namespace Vinorsoft.Core.NotiApp.Areas.Template.Controllers
{
    [VinorsoftAuthorize2(permission: new string[] { CoreConstants.View })]
    [Area("Template")]
    public class FCMTemplateController : BaseTemplateController<FCMTemplateDTO>
    {
        public FCMTemplateController(IMediator mediator, IServiceProvider serviceProvider, IMapper mapper) : base(mediator, serviceProvider, mapper)
        {
        }

        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.AddNew })]
        [ActionName("NewFCMTemplate")]
        [HttpGet]
        public override IActionResult NewItem()
        {
            return base.NewItem();
        }

        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.AddNew })]
        [ActionName("NewFCMTemplate")]
        [HttpPost]
        public override Task<IActionResult> NewItemAsync(FCMTemplateDTO newItem)
        {
            return base.NewItemAsync(newItem);
        }

        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.Edit })]
        [ActionName("UpdateFCMTemplate")]
        [HttpGet]
        public override Task<IActionResult> UpdateItemAsync(Guid id)
        {
            return base.UpdateItemAsync(id);
        }

        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.Edit })]
        [ActionName("UpdateFCMTemplate")]
        [HttpPost]
        public override Task<IActionResult> UpdateItemAsync(FCMTemplateDTO updateItem)
        {
            return base.UpdateItemAsync(updateItem);
        }
    }
}