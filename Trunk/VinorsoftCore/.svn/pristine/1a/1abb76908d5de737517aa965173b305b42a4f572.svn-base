using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using KTApps.Core.App.Attribute;
using KTApps.Core.Paging;
using KTApps.Core.Utils;
using KTApps.Domain;
using KTApps.Models;
using KTApps.Models.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KTApps.Core.App.Controllers
{
    public class KTAppCore2Controller<T, M, S> : ExportCoreController<M, S> where M : KTAppDomainModel where S : IDomainSearchModel where T : KTAppDomain
    {
        protected IDomainService<T> domainService;
        public KTAppCore2Controller(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            // domainService = serviceProvider.GetRequiredService<IDomainService<T>>();
        }

        [HttpGet]
        public virtual IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.AddNew })]
        public virtual IActionResult NewItem()
        {
            return View();
        }

        [HttpGet]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Edit })]
        public virtual IActionResult UpdateItem(Guid id)
        {
            return View();
        }

        [HttpPost]
        [ActionName("Save")]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Edit, CoreConstants.AddNew })]
        public virtual ActionResult<KTAppDomainResult> Save([FromBody]M model)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                if (ModelState.IsValid)
                {
                    T itemToSave = mapper.Map<T>(model);
                    bool success = domainService.Save(itemToSave);
                    appResult.Success = success;
                }
                else
                {
                    appResult.Messages = GetModelStateError();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, new string[] { });
                appResult.Messages.Add(ex.Message);
            }
            return appResult;
        }

        [HttpPost]
        [ActionName("Delete")]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Delete })]
        public virtual ActionResult<KTAppDomainResult> Delete([FromBody]M model)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                appResult.Success = domainService.Delete(model.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, new string[] { });
                appResult.Messages.Add(ex.Message);
            }
            return appResult;
        }

        [HttpGet]
        [ActionName("GetById")]
        public virtual ActionResult<KTAppDomainResult> GetById([FromQuery] Guid? id)
        {
            KTAppDomainResult domainResult = new KTAppDomainResult();
            try
            {
                M resultModel = null;
                if (id.HasValue)
                {
                    T doc = null;
                    var qSelect = BuildGetByIdQuery();
                    if (qSelect != null)
                    {
                        doc = domainService.GetById(id.Value, qSelect);
                    }
                    else
                    {
                        doc = domainService.GetById(id.Value);
                    }

                    if (doc != null)
                    {
                        resultModel = mapper.Map<M>(doc);
                    }

                }
                domainResult.Data = resultModel;
                domainResult.Success = true;

                return new KTAppDomainResult()
                {
                    Success = true,
                    Data = resultModel
                };

            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                domainResult.Success = true;
                domainResult.Messages.Add(ex.Message);
            }

            return domainResult;
        }

        [HttpGet]
        [ActionName("InitDropdown")]
        public virtual ActionResult<KTAppDomainResult> InitDropdown()
        {

            return new KTAppDomainResult()
            {
                Success = true,
                Data = new
                {

                }
            };
        }

        [HttpPost]
        [ActionName("GetDataTableSource")]
        public virtual ActionResult<object> GetDataTableSource([FromBody] S domainSearch)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                PagedList<T> result = null;
                var qSelect = BuildSelectQuery();
                if (qSelect != null)
                {
                    result = domainService.Get(domainSearch.WhereCondition, qSelect, domainSearch.PageIndex, domainSearch.PageSize, domainSearch.OrderBy);
                }
                else
                {
                    result = domainService.Get(domainSearch.WhereCondition, domainSearch.PageIndex, domainSearch.PageSize, domainSearch.OrderBy);
                }

                return new
                {
                    draw = domainSearch.Draw,
                    recordsTotal = result.TotalItem,
                    recordsFiltered = result.TotalItem,
                    data = mapper.Map<IList<M>>(result.Items)
                };
            }
            catch (KTAppException ex)
            {
                logger.LogError(ex, ex.Message, new string[] { });
                appResult.Messages.Add(ex.Message);
            }
            return appResult;
        }

        [HttpPost]
        [ActionName("GetData")]
        public virtual ActionResult<KTAppDomainResult> GetData([FromBody]S domainSearch)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                PagedList<T> result = null;
                var qSelect = BuildSelectQuery();
                if (qSelect != null)
                {
                    result = domainService.Get(domainSearch.WhereCondition, qSelect, domainSearch.PageIndex, domainSearch.PageSize, domainSearch.OrderBy);
                }
                else
                {
                    result = domainService.Get(domainSearch.WhereCondition, domainSearch.PageIndex, domainSearch.PageSize, domainSearch.OrderBy);
                }
                appResult.Data = mapper.Map<PagedList<M>>(result);
                appResult.Success = true;
            }
            catch (KTAppException ex)
            {
                logger.LogError(ex, ex.Message, new string[] { });
                appResult.Messages.Add(ex.Message);
            }
            return appResult;
        }

        protected virtual Expression<Func<T, T>> BuildSelectQuery()
        {
            return e => e;
        }
        protected virtual Expression<Func<T, T>> BuildGetByIdQuery()
        {
            return e => e;
        }
        protected override IList<M> GetExportData(S domainSearch)
        {
            domainSearch.Start = 0;
            domainSearch.Length = int.MaxValue;
            var results = GetDataTableSource(domainSearch).Value;
            if (results.GetType() != typeof(KTAppDomainResult))
            {
                return (IList<M>)results.GetPropValue("data");
            }
            return null;
        }
    }
}