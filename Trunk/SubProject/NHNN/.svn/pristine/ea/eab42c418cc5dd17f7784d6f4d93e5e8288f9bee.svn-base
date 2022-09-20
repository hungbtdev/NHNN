using System;
using System.ComponentModel;
using System.Linq;
using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Vinorsoft.Core;
using Vinorsoft.Core.App.Attribute;
using Vinorsoft.Core.App.Controllers;
using Vinorsoft.Core.Interface;
using Vinorsoft.NHNN.Report.DTO;
using Vinorsoft.NHNN.Report.Service.Entities;
using Vinorsoft.NHNN.Report.Service.Interface;

namespace Vinorsoft.NHNN.Report.App.Areas.Report.Controllers
{
    [Area("Report")]
    [Description("Cấu hình phân quyền dữ liệu")]
    [VinorsoftAuthorize2(permission: new string[] { CoreConstants.View })]
    public class ReportPermitController : VinorsoftCoreController<UserPermitConfigDTO, UserPermitConfigs>
    {
        readonly IUserService userService;
        readonly IUserUserPermitConfigService userUserPermitConfigService;
        public ReportPermitController(IServiceProvider serviceProvider, IMapper mapper) : base(serviceProvider, mapper)
        {
            userService = serviceProvider.GetRequiredService<IUserService>();
            userUserPermitConfigService = serviceProvider.GetRequiredService<IUserUserPermitConfigService>();
            coreService = userUserPermitConfigService;
        }

        [HttpGet]
        public object GetUsers(DataSourceLoadOptions loadOptions)
        {
            var query = userService.Queryable.Select(e => new
            {
                Id = e.Id,
                Name = $"{e.FirstName} {e.LastName} ({e.Username})"
            });
            return DataSourceLoader.Load(query, loadOptions);
        }

        [HttpGet]
        public override object Get(DataSourceLoadOptions loadOptions)
        {

            var query = userUserPermitConfigService.Queryable.Select(e => new UserPermitConfigDTO
            {
                Id = e.Id,
                Active = e.Active,
                DeptName = e.DeptName,
                Created = e.Created,
                CreatedBy = e.CreatedBy,
                Deleted = e.Deleted,
                Updated = e.Updated,
                UpdatedBy = e.UpdatedBy,
                UserId = e.UserId
            });
            return DataSourceLoader.Load(query, loadOptions);
        }

        public override IActionResult Index()
        {
            return View();
        }
    }
}