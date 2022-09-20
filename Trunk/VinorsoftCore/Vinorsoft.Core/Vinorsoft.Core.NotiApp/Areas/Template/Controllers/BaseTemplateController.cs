using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vinorsoft.Core.App.Attribute;
using Vinorsoft.Core.App.Context;
using Vinorsoft.Core.App.Controllers;
using Vinorsoft.Core.App.Extensions;
using Vinorsoft.Core.Domain.Comands;
using Vinorsoft.Core.Domain.Queries;
using Vinorsoft.Core.DTO;

namespace Vinorsoft.Core.NotiApp.Areas.Template.Controllers
{
    public abstract class BaseTemplateController<T> : CQRSCoreController<T> where T: BaseTemplateDTO, new()
    {
        public BaseTemplateController(IMediator mediator, IServiceProvider serviceProvider, IMapper mapper) : base(mediator, serviceProvider, mapper)
        {
        }

        public virtual IActionResult Index()
        {
            return View();
        }

       [HttpGet]
        public virtual IActionResult NewItem()
        {
            return View(new T()
            {
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                CreatedBy = LoginContext.Instance.CurrentUser.UserName,
            });
        }

        [HttpPost]
        public virtual async Task<IActionResult> NewItemAsync(T newItem)
        {
            try
            {
                if (!TryValidateModel(newItem))
                    throw new Exception(ModelState.GetFullErrorMessage());

                var result = await mediator.Send(new CreateComand<T>(newItem));
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
            return View(newItem);
        }

        [HttpGet]
        public virtual async Task<IActionResult> UpdateItemAsync(Guid id)
        {
            try
            {
                var result = await mediator.Send(new VQuery<T>(id));
                if (result != null)
                {
                    return View(result);
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
            return View();
        }

        [HttpPost]
        public virtual async Task<IActionResult> UpdateItemAsync(T updateItem)
        {
            try
            {
                if (!TryValidateModel(updateItem))
                    throw new Exception(ModelState.GetFullErrorMessage());

                var result = await mediator.Send(new UpdateComand<T>(updateItem));
                if (result != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
            return View(updateItem);
        }
    }
}