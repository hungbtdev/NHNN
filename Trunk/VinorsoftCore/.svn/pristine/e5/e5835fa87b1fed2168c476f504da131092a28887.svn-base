using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using KTApp.Core.Resources;
using KTApps.AuthService.Interface;
using KTApps.Core.App.Context;
using KTApps.Core.Paging;
using KTApps.Core.Utils;
using KTApps.Domain;
using KTApps.Models;
using KTApps.ShareService.Entities;
using KTApps.ShareService.Interface;
using LazyCache;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace KTApps.Core.App.Controllers
{
    public abstract class KTAppCoreController : Controller
    {
        protected readonly ILogger<KTAppCoreController> logger;
        protected readonly IServiceProvider serviceProvider;
        protected ICoreSystemConfigService systemConfigService;
        protected ICorePageTitleService pageTitleService;
        protected ICoreUploadFileService coreUploadFileService;
        protected IUserService userService;
        protected IHostingEnvironment env;
        protected const string UploadFolder = "upload";
        protected const string TemplateFolder = "template";
        public const string BaseUrl = "BaseUrl";
        public const string BaseNoAreaUrl = "BaseNoAreaUrl";
        public const string BaseHostUrl = "BaseHostUrl";
        public const string SubDomain = "SubDomain";
        public const string AreaName = "AreaName";
        protected readonly IMapper mapper;
        protected readonly IOptions<AppSettings> AppSettings;
        protected readonly IAppCache cache;
        protected static TimeSpan cacheExpiry = new TimeSpan(0, 2, 0);
        protected readonly IStringLocalizer<SharedResource> sharedLocalizer;

        public KTAppCoreController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger)
        {
            this.logger = logger;
            this.serviceProvider = serviceProvider;
            sharedLocalizer = serviceProvider.GetRequiredService<IStringLocalizer<SharedResource>>();

            userService = (IUserService)serviceProvider.GetService(typeof(IUserService));
            mapper = (IMapper)serviceProvider.GetService(typeof(IMapper));
            cache = (IAppCache)serviceProvider.GetService(typeof(IAppCache));
            systemConfigService = (ICoreSystemConfigService)serviceProvider.GetService(typeof(ICoreSystemConfigService));
            pageTitleService = (ICorePageTitleService)serviceProvider.GetService(typeof(ICorePageTitleService));
            AppSettings = (IOptions<AppSettings>)serviceProvider.GetService(typeof(IOptions<AppSettings>));
            env = (IHostingEnvironment)serviceProvider.GetService(typeof(IHostingEnvironment));
            coreUploadFileService = (ICoreUploadFileService)serviceProvider.GetService(typeof(ICoreUploadFileService));
        }

        [HttpGet]
        public virtual string GetPageTitle(string key)
        {
            if (pageTitleService != null)
            {
                CorePageTitles titles = pageTitleService.GetByCode(key);
                if (titles != null)
                {
                    return titles.Name;
                }
            }
            return string.Empty;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            string controllerName = ControllerContext.RouteData.Values["controller"].ToString();

            ViewData[SubDomain] = AppSettings.Value.SubDomain;
            ViewData[BaseNoAreaUrl] = string.Format("{0}://{1}{2}/{3}", HttpContext.Request.Scheme, HttpContext.Request.Host, AppSettings.Value.SubDomain, controllerName);
            ViewData[BaseHostUrl] = string.Format("{0}://{1}{2}", HttpContext.Request.Scheme, HttpContext.Request.Host, AppSettings.Value.SubDomain);
            if (RouteData.Values.TryGetValue("area", out object area))
            {
                ViewData[AreaName] = area;
                ViewData[BaseUrl] = string.Format("{0}://{1}{2}/{3}/{4}", HttpContext.Request.Scheme, HttpContext.Request.Host, AppSettings.Value.SubDomain, area, controllerName);
            }
            else
            {
                ViewData[BaseUrl] = string.Format("{0}://{1}{2}/{3}", HttpContext.Request.Scheme, HttpContext.Request.Host, AppSettings.Value.SubDomain, controllerName);
            }

            string key = ControllerContext.ActionDescriptor.ControllerName + "_" + ControllerContext.ActionDescriptor.ActionName;
            ViewData["Title"] = GetPageTitle(key);

            if (!pageTitleService.Exists(e => e.Code == key && !e.Deleted))
            {
                pageTitleService.Save(new CorePageTitles()
                {
                    Id = Guid.NewGuid(),
                    Created = DateTime.Now,
                    Active = true,
                    Code = key,
                    CreatedBy = string.Empty,
                    Name = key,
                    Description = key,
                });
            }

            var systemConfigValues = systemConfigService.Get(e => !e.Deleted);
            if (systemConfigValues.Count > 0)
            {
                var appname = systemConfigValues.FirstOrDefault(e => e.Code == CoreConstants.SysKey_AppName);
                if (appname != null)
                {
                    ViewData[CoreConstants.SysKey_AppName] = appname.Value;
                    ViewData[CoreConstants.SysKey_AppDescription] = appname.Description;
                }

                var footerAddress = systemConfigValues.FirstOrDefault(e => e.Code == CoreConstants.SysKey_Footer_Address);
                if (footerAddress != null)
                {
                    ViewData[CoreConstants.SysKey_Footer_Address] = footerAddress.Value;
                }

                var copyright = systemConfigValues.FirstOrDefault(e => e.Code == CoreConstants.SysKey_Copyright);
                if (copyright != null)
                {
                    ViewData[CoreConstants.SysKey_Copyright] = copyright.Value;
                }
            }

        }

        [HttpGet]
        [ActionName("Download")]
        public virtual ActionResult Download([FromQuery]string fileName)
        {
            try
            {
                if (env == null)
                {
                    throw new Exception("IHostingEnvironment is null => inject to constructor");
                }
                var webRoot = env.WebRootPath;
                string path = Path.Combine(webRoot, UploadFolder, fileName);
                var file = System.IO.File.ReadAllBytes(path);
                return File(file, "application/octet-stream", fileName);
            }
            catch (Exception ex)
            {
                if (logger != null)
                {
                    logger.LogError(ex, ex.Message, string.Empty);
                }
            }
            return View("Error");
        }

        [HttpGet]
        [ActionName("DownloadFile")]
        public virtual ActionResult Download([FromQuery]Guid fileId)
        {
            try
            {
                var file = coreUploadFileService.GetById(fileId);
                if (file != null)
                {
                    return File(file.FileContent, file.MimeType, file.Name);
                }
            }
            catch (Exception ex)
            {
                if (logger != null)
                {
                    logger.LogError(ex, ex.Message, string.Empty);
                }
            }
            return View("Error");
        }

        [HttpPost]
        [ActionName("Upload")]
        public virtual ActionResult<KTAppDomainResult> Upload([FromForm] Guid refId)
        {
            KTAppDomainResult appDomainResult = new KTAppDomainResult();
            try
            {
                if (Request.Form.Files.Count > 0)
                {
                    IList<UploadFileModel> tmpFiles = new List<UploadFileModel>();
                    foreach (var item in Request.Form.Files)
                    {
                        var tmpName = Guid.NewGuid().ToString() + Path.GetExtension(item.FileName);
                        SaveFileToTempFolder(FileUtils.StreamToByte(item.OpenReadStream()), tmpName);
                        tmpFiles.Add(new UploadFileModel()
                        {
                            Active = true,
                            Code = StringUtils.ReplaceSpecialChar(Path.GetFileNameWithoutExtension(item.FileName)),
                            FileExtension = Path.GetExtension(item.FileName),
                            Created = DateTime.Now,
                            Name = item.FileName,
                            CreatedBy = LoginContext.Instance.CurrentUser.UserName,
                            Deleted = false,
                            Description = string.Empty,
                            Id = Guid.NewGuid(),
                            MimeType = item.ContentType,
                            RefId = refId,
                            TempName = tmpName,
                        });
                    }
                    appDomainResult.Success = true;
                    appDomainResult.Data = tmpFiles;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, string.Empty);
                appDomainResult.Messages.Add(ex.Message);
            }

            return appDomainResult;
        }

        [HttpGet]
        [ActionName("GetCaptchaImage")]
        [AllowAnonymous]
        public virtual IActionResult GetCaptchaImage([FromQuery]Guid sessionId)
        {
            try
            {
                int width = 100;
                int height = 36;
                var captchaCode = Captcha.GenerateCaptchaCode();
                var result = Captcha.GenerateCaptchaImage(width, height, captchaCode);
                if (cache == null)
                {
                    throw new Exception("Lazy cache not register");
                }
                cache.Add(sessionId.ToString(), result.CaptchaCode, cacheExpiry);
                Stream s = new MemoryStream(result.CaptchaByteData);
                return new FileStreamResult(s, "image/png");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, string.Empty);
            }
            return null;
        }

        [HttpGet]
        [ActionName("FindUser")]
        public ActionResult<KTAppDomainResult> FindUser([FromQuery]string username)
        {
            KTAppDomainResult appDomainResult = new KTAppDomainResult();
            try
            {
                var user = userService.Get(e => e.Username.ToLower().Trim() == username.ToLower().ToLower())
                    .Select(e => new UserModel()
                    {
                        Id = e.Id,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Email = e.Email,
                        Phone = e.Phone,
                        Username = e.Username
                    }).FirstOrDefault();
                appDomainResult.Success = true;
                appDomainResult.Data = user;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, string.Empty);
                appDomainResult.Messages.Add(ex.Message);
            }

            return appDomainResult;
        }

        #region Protected Method

        protected IList<string> GetModelStateError()
        {
            return ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage)
                                        .ToList();
        }

        protected virtual byte[] GetFileInTempFolder(string fileName)
        {
            try
            {
                if (env == null)
                {
                    throw new Exception("IHostingEnvironment is null => inject to constructor");
                }
                var webRoot = env.WebRootPath;
                string path = Path.Combine(webRoot, UploadFolder, fileName) + ".zip";
                if (System.IO.File.Exists(path))
                {
                    using (var archive = ZipFile.Open(path, ZipArchiveMode.Read))
                    {
                        var file = archive.GetEntry(fileName);

                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (var entryStream = file.Open())
                            {
                                entryStream.CopyTo(ms);
                                return ms.ToArray();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (logger != null)
                {
                    logger.LogError(ex, ex.Message, string.Empty);
                }
            }
            return null;
        }

        private void SaveFile(byte[] fileContent, string folder, string fileName)
        {
            try
            {
                var fileExt = Path.GetExtension(fileName);
                if (string.IsNullOrEmpty(fileExt) || !UploadUtils.SafeExt.Contains(fileExt.ToLower()))
                {
                    throw new KTAppException(10027, sharedLocalizer["_10027"]);
                }

                if (env == null)
                {
                    throw new Exception("IHostingEnvironment is null => inject to constructor");
                }

                var webRoot = env.WebRootPath;
                var uploadPath = Path.Combine(webRoot, folder);
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                string path = Path.Combine(uploadPath, fileName) + ".zip";

                using (var memoryStream = new MemoryStream(fileContent))
                {
                    using (var archive = ZipFile.Open(path, ZipArchiveMode.Create))
                    {
                        var document = archive.CreateEntry(fileName);
                        using (var entryStream = document.Open())
                        {
                            memoryStream.CopyTo(entryStream);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (logger != null)
                {
                    logger.LogError(ex, ex.Message, string.Empty);
                }
            }
        }

        protected virtual void SaveFileToTempFolder(byte[] fileContent, string fileName)
        {
            try
            {
                SaveFile(fileContent, UploadFolder, fileName);
            }
            catch (Exception ex)
            {
                if (logger != null)
                {
                    logger.LogError(ex, ex.Message, string.Empty);
                }
            }
        }

        protected virtual void SaveFileToTemplateFolder(byte[] fileContent, string fileName)
        {
            try
            {
                SaveFile(fileContent, TemplateFolder, fileName);
            }
            catch (Exception ex)
            {
                if (logger != null)
                {
                    logger.LogError(ex, ex.Message, string.Empty);
                }
            }
        }

        #endregion
    }
}