using System;
using KTApps.Domain;
using KTApps.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KTApps.Core.Interface;
using System.Linq;
using System.IO;
using KTApps.Import.Dynamic;
using System.Reflection;
using System.Collections.Generic;
using KTApps.Core.Utils;
using KTApps.Models.Import;
using KTApps.Core.App.Context;
using System.Linq.Expressions;
using KTApps.Core.App.Attribute;
using Microsoft.AspNetCore.Http;
using KTApps.Core.Paging;
using KTApps.Models.Search;

namespace KTApps.Core.App.Controllers
{
    public abstract class CatalogueCoreController<T, M, DomainSearch> : KTAppCore2Controller<T, M, DomainSearch> where T : KTAppDomainCatalogue where M : KTAppDomainCatalogueModel where DomainSearch : IDomainSearchModel
    {
        protected ICatalogueService<T> catalogueService;

        public CatalogueCoreController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            domainService = catalogueService;
        }

        [HttpGet]
        public override IActionResult Index()
        {
            return View("~/Views/Catalogue/Index.cshtml");
        }

        [HttpGet]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.AddNew })]
        public override IActionResult NewItem()
        {
            return View("~/Views/Catalogue/NewItem.cshtml");
        }

        [HttpGet]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Edit })]
        public override IActionResult UpdateItem(Guid id)
        {
            return View("~/Views/Catalogue/UpdateItem.cshtml");
        }

        [HttpGet]
        [ActionName("GetData")]
        public virtual IList<T> GetData([FromQuery]string query)
        {
            IList<T> result = null;
            try
            {
                result = catalogueService.Get(e => !e.Deleted && e.Name.ToLower().Contains(query.ToLower()))
                    .Take(20)
                    .ToList();
            }
            catch (KTAppException ex)
            {
                logger.LogError(ex, ex.Message, new string[] { });
            }
            return result;
        }

        [HttpPost]
        [ActionName("Save")]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Edit, CoreConstants.AddNew })]
        public override ActionResult<KTAppDomainResult> Save([FromBody]M model)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.AutoGenerateCode)
                    {
                        model.GenerateCode();
                    }

                    return base.Save(model);
                }
                else
                {
                    appResult.Messages = GetModelStateError();
                }
            }
            catch (KTAppException ex)
            {
                logger.LogError(ex, ex.Message, new string[] { });
                appResult.Messages.Add(ex.Message);
            }
            return appResult;
        }

        [HttpPost]
        [ActionName("UploadImportFile")]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Import })]
        public virtual IActionResult ImportMapping()
        {
            try
            {
                var file = Request.Form.Files.FirstOrDefault();
                if (file != null)
                {
                    Stream stream = file.OpenReadStream();
                    ImportFileInfo importFileInfo = new ImportFileInfo();
                    importFileInfo.LoadImportFile(stream);
                }
            }
            catch (KTAppException ex)
            {
                logger.LogError(ex, ex.Message, new string[] { });
            }
            return View();
        }

        [ActionName("PrepareImport")]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Import })]
        [HttpGet]
        public virtual ActionResult<KTAppDomainResult> PrepareImport()
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                IList<ImportMappingPropertyModel> importMappingProperties = new List<ImportMappingPropertyModel>();
                PropertyInfo[] propertyInfos = typeof(M).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var item in propertyInfos)
                {
                    string description = ReflectionUtils.GetDescriptions(item);
                    if (!string.IsNullOrEmpty(description) && !importMappingProperties.Any(e => e.PropertyName == item.Name))
                    {
                        importMappingProperties.Add(new ImportMappingPropertyModel()
                        {
                            PropertyName = item.Name,
                            PropertyDescription = ReflectionUtils.GetDescriptions(item),
                            MappingWithColumn = string.Empty
                        });
                    }
                }

                appResult.Data = importMappingProperties;
                appResult.Success = true;
            }
            catch (KTAppException ex)
            {
                logger.LogError(ex, ex.Message, new string[] { });
            }
            return appResult;
        }

        [HttpGet]
        [ActionName("Import")]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Import })]
        public virtual IActionResult Import()
        {
            string key = ControllerContext.ActionDescriptor.ControllerName + "_" + ControllerContext.ActionDescriptor.ActionName;
            ViewData["Title"] = GetPageTitle(key);
            return View("~/Views/Catalogue/Import.cshtml");
        }

        [HttpPost]
        [ActionName("Import")]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Import })]
        public virtual ActionResult<KTAppDomainImportResult> Import(ImportDataModel importData)
        {
            KTAppDomainImportResult importResult = new KTAppDomainImportResult();
            try
            {
                var file = Request.Form.Files.FirstOrDefault();
                if (file != null)
                {
                    if (importData.IsUsingTemplate && importData.ImportMappings.Any())
                    {
                        importData.ImportMappings[0].MappingWithColumn = "A";
                        if (importData.ImportMappings.Count >= 2)
                            importData.ImportMappings[1].MappingWithColumn = "B";
                        if (importData.ImportMappings.Count >= 3)
                            importData.ImportMappings[2].MappingWithColumn = "C";
                        importData.StartRowIndex = 2;
                        importData.SheetName = "Sheet1";
                    }
                    Stream stream = file.OpenReadStream();
                    importData.CreatedBy = LoginContext.Instance.CurrentUser.UserName;
                    importData.FileContent = FileUtils.StreamToByte(stream);
                    importData.MimeType = file.ContentType;
                    importData.Code = StringUtils.ReplaceSpecialChar(Path.GetFileNameWithoutExtension(file.FileName));
                    importData.Name = file.FileName;
                    importData.FileExtension = Path.GetExtension(file.FileName);
                    importResult = catalogueService.Import(importData);
                    if (importResult.ResultFile != null)
                    {
                        var webRoot = env.WebRootPath;
                        string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                        string path = Path.Combine(webRoot, UploadFolder, fileName);
                        FileUtils.CreateDirectory(Path.Combine(webRoot, UploadFolder));
                        FileUtils.SaveToPath(path, importResult.ResultFile);
                        importResult.ResultFile = null;
                        importResult.DownloadFileName = fileName;



                    }
                }
            }
            catch (KTAppException ex)
            {
                logger.LogError(ex, ex.Message, new string[] { });
                importResult.Messages.Add(ex.Message);
                importResult.Success = false;
            }
            return importResult;
        }
    }
}