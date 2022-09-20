using System;
using System.ComponentModel;
using System.Linq;
using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml;
using System.IO;
using Vinorsoft.NHNN.Report.App.Areas.Report.Controllers;
using Microsoft.Extensions.Primitives;
using Vinorsoft.Core;
using Vinorsoft.Core.App.Attribute;
using Vinorsoft.NHNN.Report.DTO;
using Vinorsoft.NHNN.Report.Service.Entities;
using Vinorsoft.NHNN.Report.Service.Interface;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using Vinorsoft.Core.App.Context;

namespace Vinorsoft.NHNN.Report.App.Controllers
{
    [Area("Report")]
    [Description("Danh sách nhân viên")]
    [VinorsoftAuthorize2(permission: new string[] { CoreConstants.View })]
    public class UserListController : ReportShareController
    {
        readonly ICheckInOutService checkInOutService;
        readonly IUserConfigService userConfigService;
        readonly IUserListService userListService;
        readonly IMapper mapper;
        public UserListController(IServiceProvider serviceProvider) :base(serviceProvider)
        {
            userListService = serviceProvider.GetRequiredService<IUserListService>();
            checkInOutService = serviceProvider.GetRequiredService<ICheckInOutService>();
            userConfigService = serviceProvider.GetRequiredService<IUserConfigService>();
            mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        [HttpGet]
        public  object Get(DataSourceLoadOptions loadOptions)
        {
            IList<UserViewListDTO> dataResults = new List<UserViewListDTO>();
            try
            {
                var query = userListService.GetUserView()
                    .Where(e=> (!PhongBan.Any() || PhongBan.Contains(e.DeptName)));
                dataResults = mapper.Map<IList<UserViewListDTO>>(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return DataSourceLoader.Load(dataResults, loadOptions);
        }

        [HttpGet]
        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.Edit })]
        public IActionResult Config(string id)
        {
            UserConfigDTO userConfig = null;
            try
            {
                var userConfigInfo = userConfigService.GetUserConfigInfo(id);
                if(userConfigInfo == null)
                {
                    userConfig = new UserConfigDTO()
                    {
                        Id = Guid.NewGuid(),
                        Created = DateTime.Now,
                        CreatedBy = LoginContext.Instance.CurrentUser.UserName,
                        EmployeeNumber = id,
                        Active = true,
                        Deleted = false,
                    };
                }
                else
                {
                    userConfig = mapper.Map<UserConfigDTO>(userConfigInfo);
                }
                var userInfo = this.userListService.GetUserView().Where(e => e.EmployeeNumber == id).FirstOrDefault();
                if(userInfo != null)
                {
                    userConfig.FullName = userInfo.FullName;
                    userConfig.ParentDeptName = userInfo.ParentDeptName;
                    userConfig.DeptName = userInfo.DeptName;
                    userConfig.JobtitleName = userInfo.JobtitleName;
                }
                userConfig.IsNoCaculate = userConfig.Deleted;
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
            return View(userConfig);
        }

        [HttpPost]
        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.Edit })]
        public IActionResult Config(UserConfigDTO userConfig)
        {
            try
            {
                var config = mapper.Map<UserConfigs>(userConfig);
                config.Deleted = userConfig.IsNoCaculate;
                int result = userConfigService.UpdateIsNoCaculate(config);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
            return View(userConfig);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CheckInOutHistory(string id)
        {
            UserViewListDTO userViewListDTO = new UserViewListDTO();
            var userView = userListService.GetUserView().Where(e => e.EmployeeNumber == id).FirstOrDefault();
            if(userView != null)
            {
                userViewListDTO = mapper.Map<UserViewListDTO>(userView);
            }
            return View(userViewListDTO);
        }

        [HttpGet]
        public object GetAccessHistory(DataSourceLoadOptions loadOptions, string employeeNumber)
        {
            IList<UserViewDetailDTO> userViewDetailDTOs = new List<UserViewDetailDTO>();
            try
            {
                var userViewDetails = this.checkInOutService.GetUserViewHistory(employeeNumber);
                userViewDetailDTOs = mapper.Map<IList<UserViewDetailDTO>>(userViewDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return DataSourceLoader.Load(userViewDetailDTOs, loadOptions);
        }

        [HttpPost]
        public override IActionResult ProcessExcel([FromForm] ProcessExcelDTO processExcel)
        {
            var file = Request.Form.Files.FirstOrDefault();
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                using (var package = new ExcelPackage(ms))
                {
                    var ws = package.Workbook.Worksheets.FirstOrDefault();
                    using (var package2 = new ExcelPackage())
                    {
                        var ws2 = package2.Workbook.Worksheets.Add("sheet1", ws);

                        ws2.View.UnFreezePanes();

                        ws2.Column(1).Width = 10;
                        ws2.Column(2).Width = 25;
                        ws2.Column(3).Width = 25;
                        ws2.Column(4).Width = 25;

                        ws2 = PrintFormat(ws2, false);
                        ws2.PrinterSettings.Orientation = eOrientation.Portrait;

                        ws2 = TemplateFormat(ws2);

                        Request.Form.TryGetValue("fname", out StringValues title);

                        if (processExcel.HideVuPhong)
                        {
                            ws2 = AddHeader(ws2, title.ToString().ToUpper());
                        }
                        else
                        {
                            ws2 = AddHeader(ws2, title.ToString().ToUpper(), processExcel.Vu, processExcel.Phong);
                        }

                        var bytes = package2.GetAsByteArray();
                        var path = Path.Combine(environment.WebRootPath, "temp");
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);
                        var filename = title.ToString() + ".xlsx";

                        if (processExcel.IsPrint)
                        {
                            filename = title.ToString() + ".pdf";
                            using (DevExpress.Spreadsheet.IWorkbook workbook = new DevExpress.Spreadsheet.Workbook())
                            {
                                workbook.LoadDocument(bytes);
                                workbook.ExportToPdf(path + $"/{filename}");
                            }
                        }
                        else
                        {
                            System.IO.File.WriteAllBytes(path + $"/{filename}", bytes);
                        }

                        return Json(new
                        {
                            filename = $"{filename}",
                            url = $"/ReportShare/ViewPdf?filename={filename}",
                            processExcel.IsPrint
                        });
                    }

                }
            }
        }

    }
}