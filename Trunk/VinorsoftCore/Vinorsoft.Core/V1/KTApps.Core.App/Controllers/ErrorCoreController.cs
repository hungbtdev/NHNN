using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KTApps.Core.App.Controllers
{
    public abstract class ErrorCoreController : KTAppCoreController
    {
        public ErrorCoreController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
        }

        [Route("Error/{statusCode}")]
        [HttpGet]
        public IActionResult HandleErrorCode(int statusCode)
        {
            var statusCodeData = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 403:
                    ViewData["ErrorMessage"] = "Forbidden: You don't have permission";
                    ViewData["RouteOfException"] = statusCodeData.OriginalPath;
                    ViewData["StatusCode"] = statusCode;
                    break;
                case 404:
                    ViewData["ErrorMessage"] = "Sorry the page you requested could not be found";
                    ViewData["RouteOfException"] = statusCodeData.OriginalPath;
                    ViewData["StatusCode"] = statusCode;
                    break;
                default:
                    ViewData["ErrorMessage"] = "Sorry something went wrong on the server";
                    ViewData["RouteOfException"] = statusCodeData.OriginalPath;
                    ViewData["StatusCode"] = statusCode;
                    break;
            }

            return View("Error");
        }
    }
}