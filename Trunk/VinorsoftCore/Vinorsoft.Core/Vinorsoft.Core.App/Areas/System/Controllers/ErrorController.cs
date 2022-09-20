using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vinorsoft.Core.App.Areas.System.Controllers
{
    [AllowAnonymous]
    [Area("System")]
    [Description("Thông báo lỗi")]
    public class ErrorController : Controller
    {
        [Route("System/Error/{errorCode?}")]
        [HttpGet]
        public IActionResult Index(int errorCode)
        {
            return View("_" + errorCode);
        }
    }
}