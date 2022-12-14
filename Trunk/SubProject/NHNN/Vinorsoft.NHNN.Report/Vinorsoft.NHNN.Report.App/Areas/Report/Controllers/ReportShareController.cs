using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Vinorsoft.Core.App.Context;
using Vinorsoft.Core.App.Controllers;
using Vinorsoft.NHNN.Report.Service.Interface;

namespace Vinorsoft.NHNN.Report.App.Areas.Report.Controllers
{
    [Authorize]
    public class ReportShareController : CoreController
    {
        protected readonly IHostingEnvironment environment;
        protected readonly IUserUserPermitConfigService userUserPermitConfigService;
        public ReportShareController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.environment = serviceProvider.GetRequiredService<IHostingEnvironment>();
            userUserPermitConfigService = serviceProvider.GetRequiredService<IUserUserPermitConfigService>();
        }
        IList<int> _PermitGates;
        protected IList<int> PermitGates
        {
            get
            {
                if (_PermitGates == null)
                    _PermitGates = userUserPermitConfigService.HasPermitGate(LoginContext.Instance.CurrentUser.UserId);
                return _PermitGates;
            }
        }

        IList<string> _PhongBan;
        protected IList<string> PhongBan
        {
            get
            {
                if (_PhongBan == null)
                    _PhongBan = userUserPermitConfigService.HasPermitPb(LoginContext.Instance.CurrentUser.UserId);
                return _PhongBan;
            }
        }

        protected ExcelWorksheet PrintFormat(ExcelWorksheet ws2, bool autoFit = true)
        {
            ws2.View.UnFreezePanes();

            if (autoFit)
            {
                for (int i = 3; i <= ws2.Dimension.Columns; i++)
                {
                    ws2.Column(i).BestFit = true;
                    ws2.Column(i).AutoFit();
                }
            }
            ws2.PrinterSettings.FitToPage = true;
            ws2.PrinterSettings.FitToHeight = 0;
            ws2.PrinterSettings.PaperSize = ePaperSize.A4;
            ws2.PrinterSettings.Orientation = eOrientation.Landscape;
            ws2.PrinterSettings.BottomMargin = .3m;
            ws2.PrinterSettings.LeftMargin = .3m;
            ws2.PrinterSettings.RightMargin = .3m;
            ws2.PrinterSettings.TopMargin = .3m;
            return ws2;
        }

        protected ExcelWorksheet WeekendFormat(ExcelWorksheet ws2)
        {
            IList<int> weekendCols = new List<int>();
            for (int i = 1; i < ws2.Dimension.Columns; i++)
            {
                if (ws2.Cells[2, i].GetValue<string>() == "T.7" || ws2.Cells[2, i].GetValue<string>() == "CN")
                {
                    weekendCols.Add(i);
                }
            }
            foreach (var item in weekendCols)
            {
                Color colFromHex = ColorTranslator.FromHtml("#E4EAEB");
                ws2.Column(item).Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws2.Column(item).Style.Fill.BackgroundColor.SetColor(colFromHex);
            }
            return ws2;
        }

        protected ExcelWorksheet TemplateFormat(ExcelWorksheet ws2)
        {
            var modelTable = ws2.Cells;
            modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            modelTable.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            modelTable.Style.Font.Name = "Times New Roman";
            modelTable.Style.Font.Size = 11;
            modelTable.Style.WrapText = true;
            return ws2;
        }

        protected ExcelWorksheet AddHeader(ExcelWorksheet ws2, string header, string vu, string phong)
        {
            ws2 = AddCreator(ws2, vu, phong);

            ws2.InsertRow(1, 1);
            int countCol = ws2.Dimension.Columns;
            int countRow = ws2.Dimension.Rows;
            ws2.Cells[1, 1, 1, countCol].Merge = true;
            ws2.Cells[1, 1, 1, countCol].Style.Border.Bottom.Style = ExcelBorderStyle.None;
            ws2.Cells[1, 1, 1, countCol].Style.Border.Top.Style = ExcelBorderStyle.None;
            ws2.Cells[1, 1, 1, countCol].Style.Border.Left.Style = ExcelBorderStyle.None;
            ws2.Cells[1, 1, 1, countCol].Style.Border.Right.Style = ExcelBorderStyle.None;

            ws2.Row(1).Height = 40;

            for (int i = 3; i <= countRow; i++)
            {
                ws2.Row(i).Height = 40;
            }

            ws2.Cells[1, 1].Value = header.ToString().ToUpper().Replace("__", "\r\n"); ;
            ws2.Cells[1, 1].Style.Font.Size = 16;
            ws2.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws2.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            return ws2;
        }

        protected ExcelWorksheet AddHeader(ExcelWorksheet ws2, string header)
        {
            ws2 = AddCreator(ws2);

            ws2.InsertRow(1, 1);
            int countCol = ws2.Dimension.Columns;
            int countRow = ws2.Dimension.Rows;
            ws2.Cells[1, 1, 1, countCol].Merge = true;
            ws2.Cells[1, 1, 1, countCol].Style.Border.Bottom.Style = ExcelBorderStyle.None;
            ws2.Cells[1, 1, 1, countCol].Style.Border.Top.Style = ExcelBorderStyle.None;
            ws2.Cells[1, 1, 1, countCol].Style.Border.Left.Style = ExcelBorderStyle.None;
            ws2.Cells[1, 1, 1, countCol].Style.Border.Right.Style = ExcelBorderStyle.None;

            ws2.Row(1).Height = 40;

            for (int i = 3; i <= countRow; i++)
            {
                ws2.Row(i).Height = 40;
            }

            ws2.Cells[1, 1].Value = header.ToString().ToUpper().Replace("__", "\r\n"); ;
            ws2.Cells[1, 1].Style.Font.Size = 16;
            ws2.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws2.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            return ws2;
        }
        protected ExcelWorksheet AddCreator(ExcelWorksheet ws2)
        {
            ws2.InsertRow(1, 1);
            int countCol = ws2.Dimension.Columns;
            ws2.Cells[1, 1, 1, countCol].Merge = true;
            ws2.Cells[1, 1, 1, countCol].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            ws2.Cells[1, 1, 1, countCol].Style.Border.Top.Style = ExcelBorderStyle.None;
            ws2.Cells[1, 1, 1, countCol].Style.Border.Left.Style = ExcelBorderStyle.None;
            ws2.Cells[1, 1, 1, countCol].Style.Border.Right.Style = ExcelBorderStyle.None;

            ws2.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws2.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws2.Row(1).Height = 20;

            ws2.Cells[1, 1].Value = string.Format(Vinorsoft_NHNN_Report_DevEx_App_Resource.CreatorFormat2, LoginContext.Instance.CurrentUser.FullName, DateTime.Now);

            return ws2;
        }
        protected ExcelWorksheet AddCreator(ExcelWorksheet ws2, string vu, string phong)
        {
            ws2.InsertRow(1, 1);
            int countCol = ws2.Dimension.Columns;
            ws2.Cells[1, 1, 1, countCol].Merge = true;
            ws2.Cells[1, 1, 1, countCol].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            ws2.Cells[1, 1, 1, countCol].Style.Border.Top.Style = ExcelBorderStyle.None;
            ws2.Cells[1, 1, 1, countCol].Style.Border.Left.Style = ExcelBorderStyle.None;
            ws2.Cells[1, 1, 1, countCol].Style.Border.Right.Style = ExcelBorderStyle.None;

            ws2.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws2.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws2.Row(1).Height = 20;

            ws2.Cells[1, 1].Value = string.Format(Vinorsoft_NHNN_Report_DevEx_App_Resource.CreatorFormat, LoginContext.Instance.CurrentUser.FullName, DateTime.Now, vu, phong);

            return ws2;
        }

        protected ExcelWorksheet RemoveColumByName(ExcelWorksheet ws2, IList<string> removeTitle)
        {
            IList<int> removeCols = new List<int>();
            for (int i = 1; i <= ws2.Dimension.Columns; i++)
            {
                if (removeTitle.Any(e => e.Equals(ws2.Cells[1, i].GetValue<string>(), StringComparison.OrdinalIgnoreCase)))
                {
                    removeCols.Add(i);
                }
            }

            foreach (var item in removeCols.OrderByDescending(e => e))
            {
                ws2.DeleteColumn(item);
            }

            return ws2;
        }

        [HttpPost]
        public virtual IActionResult ProcessExcel([FromForm] ProcessExcelDTO processExcel)
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



        [HttpPost]
        public virtual IActionResult ProcessText([FromForm] ProcessExcelDTO processText)
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

                        var bytes = package2.GetAsByteArray();
                        var path = Path.Combine(environment.WebRootPath, "temp");
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);
                        var filename = title.ToString() + ".xlsx";

                        if (processText.IsPrint)
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
                            processText.IsPrint
                        });
                    }

                }
            }
        }
        [HttpGet]
        public IActionResult Download(string filename, string orgname)
        {
            var path = Path.Combine(environment.WebRootPath, "temp");
            var bytes = System.IO.File.ReadAllBytes(path + $"/{filename}");
            System.IO.File.Delete(path + $"/{filename}");
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{orgname}{Path.GetExtension(filename)}");
        }

        [HttpGet]
        public IActionResult ViewPdf(string filename)
        {
            var path = Path.Combine(environment.WebRootPath, "temp");
            //  var bytes = System.IO.File.ReadAllBytes(path + $"/{filename}");
            var stream = new FileStream(path + $"/{filename}", FileMode.Open);
            Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{filename}\"");
            Response.Headers.Add("Content-Length", stream.Length.ToString());
            return new FileStreamResult(stream, "application/pdf");
            //return File(stream, "application/pdf", $"{filename}{Path.GetExtension(filename)}");
        }
    }

    public class ProcessExcelDTO
    {
        public bool IsPrint { set; get; }
        public string ReportTitle { set; get; }
        public string Vu { set; get; }
        public string Phong { set; get; }
        public bool HideVuPhong { set; get; }
    }
}