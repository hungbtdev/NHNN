using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using DevExpress.Office.Utils;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Vinorsoft.Core;
using Vinorsoft.Core.App.Attribute;
using Vinorsoft.Core.Interface;
using Vinorsoft.NHNN.Report.DTO;
using Vinorsoft.NHNN.Report.DTO.ReportDTO;
using Vinorsoft.NHNN.Report.Service.Interface;

namespace Vinorsoft.NHNN.Report.App.Areas.Report.Controllers
{
    [Area("Report")]
    [Description("Báo cáo chấm công")]
    [VinorsoftAuthorize2(permission: new string[] { CoreConstants.View })]
    public class ReportTimeKeepingController : ReportShareController
    {
        readonly ITimeKeepingService timeKeepingService;
        readonly IUserListService userListService;
        readonly ICoreSystemConfigService coreSystemConfigService;
        readonly IUserConfigService userConfigService;
        readonly ICheckInOutService checkInOutService;

        public ReportTimeKeepingController(IServiceProvider serviceProvider, IMapper mapper) : base(serviceProvider)
        {
            timeKeepingService = serviceProvider.GetRequiredService<ITimeKeepingService>();
            userListService = serviceProvider.GetRequiredService<IUserListService>();
            coreSystemConfigService = serviceProvider.GetRequiredService<ICoreSystemConfigService>();
            userConfigService = serviceProvider.GetRequiredService<IUserConfigService>();
            checkInOutService = serviceProvider.GetRequiredService<ICheckInOutService>();

        }

        #region Properties
        public TimeSpan CheckInTimeSpan
        {
            get
            {
                var configValue = coreSystemConfigService.GetByCode(Contants.Config_CheckIn);
                if (TimeSpan.TryParseExact(configValue.Value, @"hh\:mm", null, out TimeSpan interval))
                    return interval;
                return new TimeSpan();
            }
        }
        public TimeSpan CheckOutTimeSpan
        {
            get
            {
                var configValue = coreSystemConfigService.GetByCode(Contants.Config_CheckOut);
                if (TimeSpan.TryParseExact(configValue.Value, @"hh\:mm", null, out TimeSpan interval))
                    return interval;
                return new TimeSpan();
            }
        }
        public int StandardCheckInHour
        {
            get
            {
                if (CheckInTimeSpan.Hours <= 0)
                    return 8;
                return CheckInTimeSpan.Hours;
            }
        }
        public int StandardCheckInMinute
        {
            get
            {
                if (CheckInTimeSpan.Minutes <= 0)
                    return 0;
                return CheckInTimeSpan.Minutes;
            }
        }
        public int StandardCheckOutHour
        {
            get
            {
                if (CheckOutTimeSpan.Hours <= 0)
                    return 17;
                return CheckOutTimeSpan.Hours;
            }
        }
        public int StandardCheckOutMinute
        {
            get
            {
                if (CheckOutTimeSpan.Minutes <= 0)
                    return 0;
                return CheckOutTimeSpan.Minutes;
            }
        }
        public int TotalAllowLateMinute
        {
            get
            {
                var configValue = coreSystemConfigService.GetByCode(Contants.Config_LateMinuteAllow);
                if (int.TryParse(configValue.Value, out int value))
                    return value;
                return 0;
            }
        }
        #endregion

        [HttpGet]
        public IActionResult Index(int? month, int? year)
        {
            SearchReportTimeKeepingDTO searchReportTimeKeeping = new SearchReportTimeKeepingDTO
            {
                Month = month ?? DateTime.Now.Month,
                Year = year ?? DateTime.Now.Year
            };
            return View(searchReportTimeKeeping);
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions, int month, int year)
        {
            #region
            //var userIds = userConfigService.Queryable.Where(e => e.IsNoCaculate).Select(e => e.UserId).ToList();
            //var userIds = new List<int>();
            //var userList = userListService.Queryable.Select(e => new UserListDTO()
            //{
            //    ChucVu = e.ChucVu ?? "",
            //    Cuc = e.Cuc ?? "",
            //    FirstName = e.FirstName ?? "",
            //    Name = e.Name ?? "",
            //    IdUser = e.IdUser,
            //    IDNumber = e.IDNumber ?? "",
            //    Phong = e.Phong ?? "",
            //    LogicalCode = e.LogicalCode ?? "",
            //}).ToList();

            //var query = timeKeepingService.Queryable
            //    .Where(e => e.Dat.Month == month && e.Dat.Year == year && !string.IsNullOrEmpty(e.Codelogique) && !e.Codelogique.StartsWith(UserListDTO.Prefix_THE, StringComparison.OrdinalIgnoreCase) && e.IdUsager.HasValue && !userIds.Contains(e.IdUsager.Value))
            //    .GroupBy(e => new
            //    {
            //        e.IdUsager
            //    }).Select(e => new ReportTimeKeepingDTO()
            //    {
            //        Key = e.Key.IdUsager,
            //        User = userList.FirstOrDefault(s => s.IdUser == e.Key.IdUsager),
            //        StandardCheckInHour = StandardCheckInHour,
            //        StandardCheckOutHour = StandardCheckOutHour,
            //        StandardCheckInMinute = StandardCheckInMinute,
            //        StandardCheckOutMinute = StandardCheckOutMinute,
            //        TotalAllowLateMinute = TotalAllowLateMinute,
            //        AccessHistoricals = e.Where(s => !string.IsNullOrEmpty(s.LibelleCircuit)).Select(s => new AccessHistoricalDTO()
            //        {
            //            Dat = s.Dat,
            //            LibelleCircuit = s.LibelleCircuit,
            //            IdUsager = s.IdUsager,
            //            Id = s.Id,
            //            Nom = s.Nom,
            //            Prenom = s.Prenom,
            //            Codelogique = s.Codelogique,
            //            DescriptionCircuit = s.DescriptionCircuit
            //        }).ToList()
            //    });
            #endregion

            var query = checkInOutService.GetVwLogAccesses().Where(e =>
            e.CheckInOutTime.Value.Month == month &&
            e.CheckInOutTime.Value.Year == year &&
            (!PhongBan.Any() || PhongBan.Contains(e.DeptName))
            )
               .GroupBy(e => new
               {
                   e.EmployeeNumber,
                   e.FullName,
                   e.DeptName,
                   e.ParentDeptName,
                   e.JobtitleName
               })
               .Select(e => new TimeKeepingRowDTO()
               {

                   EmployeeNumber = e.Key.EmployeeNumber,
                   FullName = e.Key.FullName,
                   DeptName = e.Key.DeptName,
                   ParentDeptName = e.Key.ParentDeptName,
                   JobtitleName = e.Key.JobtitleName,
                   VwLogAccess = e.Select(c => new VwLogAccessDTO()
                   {
                       CheckInOutTime = c.CheckInOutTime,
                       Door = c.Door,
                       Day = c.Day,
                       InOutType = c.InOutType,
                       DayOfWeek = c.DayOfWeek,
                       EmployeeNumber = c.EmployeeNumber,
                       Month = c.Month,
                       Year = c.Year,
                   }).ToList(),
               }).ToList();
            return DataSourceLoader.Load(query, loadOptions);
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

                        ws2.Column(1).Width = 8;
                        ws2.Column(2).Width = 20;
                        IList<string> removeTitle = new string[] { "Phòng ban", "Đơn vị", "Chức vụ" };
                        ws2 = RemoveColumByName(ws2, removeTitle);

                        ws2 = PrintFormat(ws2);

                        ws2 = WeekendFormat(ws2);

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

                        int countCol = ws2.Dimension.Columns;
                        int countRow = ws2.Dimension.Rows;

                        for (int i = 5; i <= countRow; i++)
                        {
                            if (ws2.Cells[i, 1].Value != null && (ws2.Cells[i, 1].Value.ToString()).Contains(@"Phòng ban: "))
                            {
                                ws2.Cells[i, 1, i, countCol].Merge = true;
                                ws2.Cells[i, 1, i, countCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            }
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


        public override IActionResult ProcessText([FromForm] ProcessExcelDTO processText)
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

                        ws2.Column(1).Width = 8;
                        ws2.Column(2).Width = 20;
                        //IList<string> removeTitle = new string[] { "Phòng ban", "Đơn vị", "Chức vụ" };
                        //ws2 = RemoveColumByName(ws2, removeTitle);

                        ws2 = PrintFormat(ws2);

                        ws2 = WeekendFormat(ws2);

                        ws2 = TemplateFormat(ws2);
                        try
                        {
                            var path = Path.Combine(environment.WebRootPath, "temp");

                            Request.Form.TryGetValue("fname", out StringValues title);
                            if (!Directory.Exists(path))
                                Directory.Delete(path);
                            Directory.CreateDirectory(path);
                            var filename = title.ToString() + ".txt";

                            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, filename), true))
                            {
                                if (processText.HideVuPhong)
                                {
                                    ws2 = AddHeader(ws2, title.ToString().ToUpper());
                                }
                                else
                                {
                                    ws2 = AddHeader(ws2, title.ToString().ToUpper(), processText.Vu, processText.Phong);
                                }

                                int countCol = ws2.Dimension.Columns;
                                int countRow = ws2.Dimension.Rows;

                                for (int i = 0; i <= countCol; i++)
                                {
                                    if (i == 0)
                                    {
                                        outputFile.Write("Mã CC    |");
                                    }
                                    else if (i == 1)
                                    {
                                        outputFile.Write("Họ và tên         |");
                                    }
                                    //else if (i == 2)
                                    //{
                                    //    outputFile.Write("Đơn vị            |");
                                    //}
                                    //else if (i == 3)
                                    //{
                                    //    outputFile.Write("Chức vụ            |");
                                    //}
                                    else if (i < countCol)
                                    {
                                        outputFile.Write((i - 3).ToString() + " |");
                                    }
                                    else
                                    {
                                        outputFile.Write((i - 3).ToString() + "    |\n");
                                    }


                                }
                                for (int i = 5; i <= countRow; i++)
                                {
                                    if (ws2.Cells[i, 1].Value != null && (ws2.Cells[i, 1].Value.ToString()).Contains(@"Phòng ban: "))
                                    {
                                        ws2.Row(i).Merged = true;
                                        ws2.Row(i).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                                    }
                                    for (int j = 1; j <= countCol; j++)
                                    {
                                        if (i > 5)
                                        {
                                            string content = "0";
                                            if (ws2.Cells[i, j].Value != null)
                                            {
                                                content = ws2.Cells[i, j].Value.ToString();
                                            }
                                            if (j == countCol)
                                            {
                                                outputFile.Write(content + "    |\n");
                                            }
                                            else
                                            {
                                                outputFile.Write(content + "    |");
                                            }
                                        }
                                    }
                                }
                            }


                            return Json(new
                            {
                                filename = $"{filename}",
                                url = $"/ReportShare/ViewPdf?filename={filename}",
                                processText.IsPrint
                            });
                        }
                        catch (Exception Ex)
                        {
                            Console.WriteLine(Ex.ToString());
                            return Json(new
                            {

                            });
                        }
                    }

                }


            }
        }
    }
}