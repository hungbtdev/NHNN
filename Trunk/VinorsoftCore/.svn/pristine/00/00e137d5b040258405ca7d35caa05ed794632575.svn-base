using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Vinorsoft.Core.App.Attribute;
using Vinorsoft.Core.Domain;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.App.Controllers
{
    public abstract class VinorsoftCatalogueCoreController<DTO, Entity> : VinorsoftCoreController<DTO, Entity> where DTO : CatalogueObjectDTO, new() where Entity : VinorsoftCatalogueDomain
    {
        public VinorsoftCatalogueCoreController(IServiceProvider serviceProvider, IMapper mapper) : base(serviceProvider, mapper)
        {
        }

        [HttpGet]
        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.View })]
        public override IActionResult Index()
        {
            return View("_CatalogueView");
        }

        [HttpGet]
        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.View })]
        public override object Get(DataSourceLoadOptions loadOptions)
        {
            try
            {
                loadOptions.DefaultSort = "Name";
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

        public override IActionResult Insert(string values)
        {
            var newItem = new DTO();
            JsonConvert.PopulateObject(values, newItem);
            newItem.Id = Guid.NewGuid();

            if (!VerifyCode(newItem.Id, newItem.Code))
            {
                return BadRequest(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, newItem.Code));
            }

            return base.Insert(values);
        }

        public override IActionResult Update(Guid key, string values)
        {
            var updateItem = coreService.GetById(key);
            JsonConvert.PopulateObject(values, updateItem);
            if (!VerifyCode(updateItem.Id, updateItem.Code))
            {
                return BadRequest(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, updateItem.Code));
            }

            return base.Update(key, values);
        }


        /// <summary>
        /// Check code is valid
        /// true: if code is valid
        /// false: if code invalid
        /// </summary>
        /// <param name="id"></param>
        /// <param name="code"></param>
        /// <returns>
        /// true: if code is valid
        /// false: if code invalid
        /// </returns>

        protected bool VerifyCode(Guid id, string code)
        {
            if (coreService.Any(e => e.Id != id && e.Code == code))
            {
                return false;
            }
            return true;
        }
    }
}