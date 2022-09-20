using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Vinorsoft.Core.App.Attribute;
using Vinorsoft.Core.App.Extensions;
using Vinorsoft.Core.Domain;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core.App.Controllers
{
    public abstract class VinorsoftCoreController<DTO, Entity> : CoreController where DTO : DomainObjectDTO, new() where Entity : VinorsoftDomain
    {
        protected ICoreService<Entity> coreService;
        protected readonly IMapper mapper;
        public VinorsoftCoreController(IServiceProvider serviceProvider, IMapper mapper) : base(serviceProvider)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.View })]
        public virtual IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.View })]
        public virtual object Get(DataSourceLoadOptions loadOptions)
        {
            try
            {
                var query = coreService.Queryable
               .ProjectTo<DTO>(mapper.ConfigurationProvider);
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
        public virtual IActionResult Insert(string values)
        {
            try
            {
                var newItem = new DTO();
                JsonConvert.PopulateObject(values, newItem);
                newItem.Id = Guid.NewGuid();
                if (!TryValidateModel(newItem))
                    return BadRequest(ModelState.GetFullErrorMessage());
                int result = coreService.Insert(mapper.Map<Entity>(newItem));
                if (result > 0)
                    return Ok(newItem);
                return BadRequest();
            }
            catch (Exception ex)
            {
                HandleError(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.Edit })]
        public virtual IActionResult Update(Guid key, string values)
        {
            try
            {
                var updateItem = coreService.GetById(key);
                JsonConvert.PopulateObject(values, updateItem);
                if (!TryValidateModel(updateItem))
                    return BadRequest(ModelState.GetFullErrorMessage());
                int result = coreService.Update(updateItem);
                if (result > 0)
                    return Ok(updateItem);
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
        public virtual void Delete(Guid key)
        {
            try
            {
                int result = coreService.Delete(key);
            }
            catch (Exception ex)
            {
                HandleError(ex);
                throw ex;
            }
        }

    }
}