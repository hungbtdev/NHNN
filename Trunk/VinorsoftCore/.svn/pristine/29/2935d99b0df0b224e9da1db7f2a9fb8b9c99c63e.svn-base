using System;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vinorsoft.Core.App.Attribute;
using Vinorsoft.Core.DTO;

namespace Vinorsoft.Core.App.Controllers
{
    public abstract class CQRSCatalogueCoreController<DTO> : CQRSCoreController<DTO> where DTO : CatalogueObjectDTO, new()
    {
        protected CQRSCatalogueCoreController(IMediator mediator, IServiceProvider serviceProvider, IMapper mapper) : base(mediator, serviceProvider, mapper)
        {
        }

        [HttpGet]
        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.View })]
        public virtual IActionResult Index()
        {
            return View("_CatalogueView");
        }
    }
}