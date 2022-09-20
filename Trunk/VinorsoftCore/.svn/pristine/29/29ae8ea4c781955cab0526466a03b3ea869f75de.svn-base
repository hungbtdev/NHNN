using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KTApps.Core.LoggingService.Entities;
using KTApps.Core.LoggingService.Interface;
using KTApps.Domain;
using KTApps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KTApps.Core.App.Controllers
{
    public abstract class ActivityCoreController : KTAppCoreController
    {
        readonly IActivityLoggingService activityLoggingService;
        public ActivityCoreController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            activityLoggingService = serviceProvider.GetRequiredService<IActivityLoggingService>();
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ActionName("GetData")]
        public virtual async Task<ActionResult<KTAppDomainResult>> GetData([FromBody]SearchCatalogueModel searchCatalogue)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                Expression<Func<CoreApiLogItems, bool>> condition = e => !e.Deleted &&
                (!string.IsNullOrEmpty(searchCatalogue.SearchContent) || e.UserName.Contains(searchCatalogue.SearchContent) || e.Path.Contains(searchCatalogue.SearchContent));
                Expression<Func<CoreApiLogItems, CoreApiLogItems>> select = e => new CoreApiLogItems()
                {
                    Id = e.Id,
                    Created = e.Created,
                    Method = e.Method,
                    Path = e.Path,
                    QueryString = e.QueryString,
                    RequestBody = e.RequestBody,
                    RequestTime  = e.RequestTime,
                    ResponseMillis = e.ResponseMillis,
                    StatusCode =e.StatusCode,
                    UserId = e.UserId,
                    UserName = e.UserName
                };
                appResult.Data = await activityLoggingService.GetAsync(condition, searchCatalogue.PageIndex, searchCatalogue.PageSize, "Created");
                appResult.Success = true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, new string[] { });
                appResult.Messages.Add(ex.Message);
            }
            return appResult;
        }

    }
}