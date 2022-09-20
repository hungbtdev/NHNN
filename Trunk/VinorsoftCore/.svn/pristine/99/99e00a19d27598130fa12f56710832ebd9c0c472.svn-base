using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Vinorsoft.Core.App.Attribute;
using Vinorsoft.Core.App.Extensions;
using Vinorsoft.Core.Domain.Comands;
using Vinorsoft.Core.Domain.Queries;
using Vinorsoft.Core.DTO;

namespace Vinorsoft.Core.App.Controllers
{
    public abstract class CQRSCoreController<DTO> : CoreController where DTO : DomainObjectDTO, new()
    {
        protected readonly IMediator mediator;
        protected readonly IMapper mapper;

        protected CQRSCoreController(IMediator mediator, IServiceProvider serviceProvider, IMapper mapper) : base(serviceProvider)
        {
            this.mediator = mediator ?? throw new ArgumentNullException();
            this.mapper = mapper ?? throw new ArgumentNullException();
        }

        protected virtual async Task<TResult> QueryAsync<TResult>(IRequest<TResult> query)
        {
            return await mediator.Send(query);
        }

        protected virtual ActionResult<T> Single<T>(T data)
        {
            if (data == null) return NotFound();
            return Ok(data);
        }

        protected async Task<TResult> CommandAsync<TResult>(IRequest<TResult> command)
        {
            return await mediator.Send(command);
        }

        [HttpGet]
        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.View })]
        [ActionName("Get")]
        public virtual async Task<object> GetAsync(DataSourceLoadOptions loadOptions)
        {
            try
            {
                var query = await mediator.Send(new VQueryable<IQueryable<DTO>>());
                return DataSourceLoader.Load(query, loadOptions);
            }
            catch (Exception ex)
            {
                HandleError(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.AddNew })]
        [ActionName("Insert")]
        public virtual async Task<IActionResult> InsertAsync(string values)
        {
            try
            {
                var newItem = new DTO();
                JsonConvert.PopulateObject(values, newItem);
                newItem.Id = Guid.NewGuid();
                if (!TryValidateModel(newItem))
                    return BadRequest(ModelState.GetFullErrorMessage());

                var result = await mediator.Send(new CreateComand<DTO>(newItem));
                if (result != null)
                    return Ok(result);
                return BadRequest();
            }
            catch (Exception ex)
            {
                HandleError((Exception)ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.Edit })]
        [ActionName("Update")]
        public virtual async Task<IActionResult> UpdateAsync(Guid key, string values)
        {
            try
            {
                var updateItem = await mediator.Send(new VQuery<DTO>(key));
                JsonConvert.PopulateObject(values, updateItem);
                if (!TryValidateModel(updateItem))
                    return BadRequest(ModelState.GetFullErrorMessage());
                var result = await mediator.Send(new UpdateComand<DTO>(mapper.Map<DTO>(updateItem)));
                if (result != null)
                    return Ok(result);
                return BadRequest();
            }
            catch (Exception ex)
            {
                HandleError(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.Delete })]
        [ActionName("Delete")]
        public virtual async Task DeleteAsync(Guid key)
        {
            try
            {
                await mediator.Send(new DeleteComand<DTO>(new DTO() { Id = key }));
            }
            catch (Exception ex)
            {
                //HandleError(ex);
                throw ex;
            }
        }
    }
}