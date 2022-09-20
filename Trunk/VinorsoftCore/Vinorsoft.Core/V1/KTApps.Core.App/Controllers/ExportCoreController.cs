using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KTApps.Core.Utils;
using KTApps.Domain;
using KTApps.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KTApps.Core.App.Controllers
{
    public abstract class ExportCoreController<T, S> : KTAppCoreController where T : class where S : IDomainSearchModel
    {
        public ExportCoreController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            env = serviceProvider.GetRequiredService<IHostingEnvironment>();
        }

        [HttpPost]
        [ActionName("Export")]
        public virtual ActionResult<KTAppDomainResult> Export([FromBody]S domainSearch)
        {
            KTAppDomainResult appDomainResult = new KTAppDomainResult();
            try
            {
                return ExportWithParams(domainSearch, new Dictionary<string, object>());
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                appDomainResult.Messages.Add(ex.Message);
            }

            return appDomainResult;
        }

        protected ActionResult<KTAppDomainResult> ExportWithParams(S domainSearch, IDictionary<string, object> parameters)
        {
            return ExportWithParams(domainSearch, parameters, null, null);
        }

        protected ActionResult<KTAppDomainResult> ExportWithParams(S domainSearch, IDictionary<string, object> parameters, string templateName, Action<IList<T>> extendMethod)
        {
            KTAppDomainResult appDomainResult = new KTAppDomainResult();
            try
            {
                if (string.IsNullOrEmpty(templateName))
                {
                    templateName = string.Format("Template_{0}_{1}", ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName);
                }

                var file = coreUploadFileService.Get(e => e.Code == templateName).ToList().FirstOrDefault();
                if (file == null)
                {
                    throw new Exception("Template not exists");
                }

                var result = GetExportData(domainSearch);
                var webRoot = env.WebRootPath;

                extendMethod?.Invoke(result);

                var fileResult = result.GetByteExport(file.FileContent, parameters);

                string fileName = GenerateFileName(file.Name);

                string path = Path.Combine(webRoot, UploadFolder, fileName);
                FileUtils.CreateDirectory(Path.Combine(webRoot, UploadFolder));
                FileUtils.SaveToPath(path, fileResult);
                fileResult = null;
                appDomainResult.Data = fileName;
                appDomainResult.Success = true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                appDomainResult.Messages.Add(ex.Message);
            }

            return appDomainResult;
        }

        protected virtual string GenerateFileName(string fileNameOfTemplate)
        {
            return string.Format("{0:ddMMyyyyHHmmss}_{1}", DateTime.Now, fileNameOfTemplate);
        }

        protected abstract IList<T> GetExportData(S domainSearch);
    }
}