using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Vinorsoft.Core.App.Context;
using Vinorsoft.Core.Domain.Comands;
using Vinorsoft.Core.Domain.Queries;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core.App.Controllers.Core
{
    [Area("Media")]
    [Description("Kho hình ảnh")]
    [Authorize]
    public class GaleryController : CQRSCoreController<CoreUploadFileDTO>
    {
        private readonly IHostingEnvironment env;
        private readonly ICoreUploadFileService coreUploadFileService;
        public GaleryController(IMediator mediator, IServiceProvider serviceProvider, IMapper mapper) : base(mediator, serviceProvider, mapper)
        {
            env = serviceProvider.GetRequiredService<IHostingEnvironment>();
            coreUploadFileService = serviceProvider.GetRequiredService<ICoreUploadFileService>();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GaleryItem()
        {
            return View(new CoreUploadFileDTO()
            {
                Id = Guid.NewGuid()
            });
        }

        [HttpPost]
        public async Task<IActionResult> GaleryItem(CoreUploadFileDTO coreUploadFile)
        {
            try
            {
                if (HttpContext.Request.Form.Files.Count() > 0)
                {
                    foreach (var file in HttpContext.Request.Form.Files)
                    {

                        if (file.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                file.CopyTo(ms);
                                coreUploadFile.CreatedBy = LoginContext.Instance.CurrentUser.UserName;
                                coreUploadFile.FileExtension = Path.GetExtension(file.FileName);
                                coreUploadFile.MimeType = file.ContentDisposition;
                                coreUploadFile.FileContent = ms.ToArray();
                                coreUploadFile.Created = DateTime.Now;
                                await mediator.Send(new CreateComand<CoreUploadFileDTO>(coreUploadFile));
                                return RedirectToAction(nameof(Index));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
                return BadRequest(ex.Message);
            }
            return View(coreUploadFile);
        }

        [HttpGet]
        [ActionName("Image")]
        public async Task<IActionResult> ImageAsync(Guid id)
        {
            var image = await mediator.Send(new VQuery<CoreUploadFileDTO>(id));
            if (image != null)
                return File(image.FileContent, "image/jpeg");

            string path = Path.Combine(env.WebRootPath, "css", "images");
            var defaultImage = System.IO.File.ReadAllBytes($"{path}/default.png");
            return File(defaultImage, "image/jpeg"); ;
        }

        [HttpGet]
        [ActionName("ImageWithCode")]
        public IActionResult Image(string code)
        {
            var image = coreUploadFileService.GetByCode(code);
            if (image != null)
                return File(image.FileContent, "image/jpeg");

            string path = Path.Combine(env.WebRootPath, "css", "images");
            var defaultImage = System.IO.File.ReadAllBytes($"{path}/default.png");
            return File(defaultImage, "image/jpeg"); ;
        }
    }
}