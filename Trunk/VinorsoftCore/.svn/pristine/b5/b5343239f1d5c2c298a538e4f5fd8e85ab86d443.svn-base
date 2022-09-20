using System;
using System.Linq.Expressions;
using KTApps.Core.App.Attribute;
using KTApps.Core.App.Models;
using KTApps.Domain;
using KTApps.Models;
using KTApps.Models.Search;
using KTApps.ShareService.Entities;
using KTApps.ShareService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KTApps.Core.App.Controllers
{
    public abstract class UploadCoreController : CatalogueCoreController<CoreUploadFiles, CoreUploadFileModel, SearchCatalogueModel>
    {
        public UploadCoreController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            domainService = serviceProvider.GetRequiredService<ICoreUploadFileService>();
        }

        [HttpGet]
        public override IActionResult Index()
        {
            return View("~/Views/Upload/Index.cshtml");
        }

        [HttpGet]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.AddNew })]
        public override IActionResult NewItem()
        {
            return View("~/Views/Upload/NewItem.cshtml");
        }


        [HttpPost]
        [ActionName("Save")]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Edit, CoreConstants.AddNew })]
        public override ActionResult<KTAppDomainResult> Save([FromBody]CoreUploadFileModel item)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                if (ModelState.IsValid)
                {
                    CoreUploadFiles itemToSave = mapper.Map<CoreUploadFiles>(item);
                    itemToSave.FileContent = GetFileInTempFolder(item.TempName);
                    if (itemToSave.FileContent == null)
                    {
                        throw new KTAppException(10028, sharedLocalizer["_10028"]);
                    }
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

        protected override Expression<Func<CoreUploadFiles, CoreUploadFiles>> BuildSelectQuery()
        {
            return e => new CoreUploadFiles()
            {
                Id = e.Id,
                Active = e.Active,
                Code = e.Code,
                Created = e.Created,
                CreatedBy = e.CreatedBy,
                Deleted = e.Deleted,
                Description = e.Description,
                FileExtension = e.FileExtension,
                Name = e.Name,
                MimeType = e.MimeType,
                RefId = e.RefId,
            };
        }
    }
}