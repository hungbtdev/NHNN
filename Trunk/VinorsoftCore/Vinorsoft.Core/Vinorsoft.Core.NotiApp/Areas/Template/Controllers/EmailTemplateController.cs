using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Vinorsoft.Core.App.Attribute;
using Vinorsoft.Core.DTO;

namespace Vinorsoft.Core.NotiApp.Areas.Template.Controllers
{
    [Area("Template")]
    [VinorsoftAuthorize2(permission: new string[] { CoreConstants.View })]
    public class EmailTemplateController : BaseTemplateController<EmailTemplateDTO>
    {
        public EmailTemplateController(IMediator mediator, IServiceProvider serviceProvider, IMapper mapper) : base(mediator, serviceProvider, mapper)
        {
        }

        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.AddNew })]
        [ActionName("NewEmailTemplate")]
        [HttpGet]
        public override IActionResult NewItem()
        {
            return base.NewItem();
        }

        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.AddNew })]
        [ActionName("NewEmailTemplate")]
        [HttpPost]
        public override Task<IActionResult> NewItemAsync(EmailTemplateDTO newItem)
        {
            return base.NewItemAsync(newItem);
        }

        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.Edit })]
        [ActionName("UpdateEmailTemplate")]
        [HttpGet]
        public override Task<IActionResult> UpdateItemAsync(Guid id)
        {
            return base.UpdateItemAsync(id);
        }

        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.Edit })]
        [ActionName("UpdateEmailTemplate")]
        [HttpPost]
        public override Task<IActionResult> UpdateItemAsync(EmailTemplateDTO updateItem)
        {
            return base.UpdateItemAsync(updateItem);
        }
    }
}