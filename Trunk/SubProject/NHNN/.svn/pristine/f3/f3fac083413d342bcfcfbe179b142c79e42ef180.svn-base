using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using OfficeOpenXml;
using Vinorsoft.Core;
using Vinorsoft.Core.App.Attribute;
using Vinorsoft.NHNN.Report.DTO;
using Vinorsoft.NHNN.Report.Service.Interface;

namespace Vinorsoft.NHNN.Report.App.Areas.Report.Controllers
{
    [Area("Report")]
    [Description("Báo cáo xe")]
    [VinorsoftAuthorize2(permission: new string[] { CoreConstants.View })]
    public class ReportCarController : ReportShareController
    {
        readonly ICarReportService carReportService;
        readonly IUserListService userListService;
        public ReportCarController(IServiceProvider serviceProvider, IMapper mapper) :base (serviceProvider)
        {
            carReportService = serviceProvider.GetRequiredService<ICarReportService>();
            userListService = serviceProvider.GetRequiredService<IUserListService>();
        }

        [HttpGet]
        public IActionResult Index(int? month, int? year)
        {
            SearchReportCarDTO searchReportCar = new SearchReportCarDTO()
            {
                Month = month ?? DateTime.Now.Month,
                Year = year ?? DateTime.Now.Year
            };
            return View(searchReportCar);
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions, int month, int year)
        {
            //var query = carReportService.Queryable
            //    .Where(e => e.Dat.Month == month && e.Dat.Year == year && !string.IsNullOrEmpty(e.LibHisto)
            //    && e.IdCircuit.HasValue && e.CircType == 8 && !e.IdUsager.HasValue)
            //    .GroupBy(e => new
            //    {
            //        e.LibHisto,   
            //    }).Select(e => new ReportCarDTO()
            //    {
            //        Key = e.Key.LibHisto,
            //        LibHisto=e.Key.LibHisto,
            //        IsCarReport =true,
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
            //        }).OrderBy(x=>x.Dat).ToList()
            //    });
            //return DataSourceLoader.Load(query, loadOptions);

            return null;
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

                        ws2 = PrintFormat(ws2);

                        ws2 = WeekendFormat(ws2);

                        ws2 = TemplateFormat(ws2);

                        Request.Form.TryGetValue("fname", out StringValues title);
                        ws2 = AddHeader(ws2, title, processExcel.Vu, processExcel.Phong);

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
                                for (int i = 1; i <= countRow; i++)
                                {
                                    workbook.Worksheets[0].Rows[i].AutoFit();
                                }
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