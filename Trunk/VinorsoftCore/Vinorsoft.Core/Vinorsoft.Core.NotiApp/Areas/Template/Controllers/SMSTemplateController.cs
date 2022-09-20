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
    public class SMSTemplateController : BaseTemplateController<SMSTemplateDTO>
    {
        public SMSTemplateController(IMediator mediator, IServiceProvider serviceProvider, IMapper mapper) : base(mediator, serviceProvider, mapper)
        {
        }

        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.AddNew })]
        [ActionName("NewSMSTemplate")]
        [HttpGet]
        public override IActionResult NewItem()
        {
            return base.NewItem();
        }

        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.AddNew })]
        [ActionName("NewSMSTemplate")]
        [HttpPost]
        public override Task<IActionResult> NewItemAsync(SMSTemplateDTO newItem)
        {
            return base.NewItemAsync(newItem);
        }

        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.Edit })]
        [ActionName("UpdateSMSTemplate")]
        [HttpGet]
        public override Task<IActionResult> UpdateItemAsync(Guid id)
        {
            return base.UpdateItemAsync(id);
        }

        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.Edit })]
        [ActionName("UpdateSMSTemplate")]
        [HttpPost]
        public override Task<IActionResult> UpdateItemAsync(SMSTemplateDTO updateItem)
        {
            return base.UpdateItemAsync(updateItem);
        }
    }
}