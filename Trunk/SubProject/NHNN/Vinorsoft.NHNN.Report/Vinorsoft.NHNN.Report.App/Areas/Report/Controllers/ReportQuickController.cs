using System;
using System.Collections.Generic;
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
    [Description("Báo cáo tức thời")]
    [VinorsoftAuthorize2(permission: new string[] { CoreConstants.View })]
    public class ReportQuickController : ReportShareController
    {
        //readonly IHistoriqueService vueHistoService;
        //readonly IAccesService accesService;
        readonly IUserListService userListService;
        protected IMapper mapper;
        public ReportQuickController(IServiceProvider serviceProvider, IMapper mapper) : base(serviceProvider)
        {
            //vueHistoService = serviceProvider.GetRequiredService<IHistoriqueService>();
            //accesService = serviceProvider.GetRequiredService<IAccesService>();
            userListService = serviceProvider.GetRequiredService<IUserListService>();
            this.mapper = mapper;
        }

        public IActionResult Index(DateTime? searchDate, int? startHour, int? endHour, bool? inside)
        {
            SearchReportQuickDTO searchReportQuick = new SearchReportQuickDTO()
            {
                SearchDate = searchDate ?? DateTime.Now.Date,
                StartHour = startHour ?? 0,
                EndHour = endHour ?? 23,
                Inside = inside ?? false,

            };
            return View(searchReportQuick);
        }

        /// <summary>
        /// Lấy thông tin danh sách
        /// </summary>
        /// <param name="loadOptions"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="inside"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetV2(DataSourceLoadOptions loadOptions, DateTime? startDate, DateTime? endDate, bool inside)
        {
            IList<UserViewDetailDTO> data = new List<UserViewDetailDTO>();
            try
            {
                var userViewDetails = this.userListService.GetUserViewDetail(startDate, endDate, inside);
                data = mapper.Map<IList<UserViewDetailDTO>>(userViewDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return DataSourceLoader.Load(data, loadOptions);
        }


        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions, DateTime? startDate, DateTime? endDate, bool? inside)
        {
            //var accessList = accesService.Queryable.ToList();
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

            //if (inside.HasValue && inside.Value)
            //{
            //    var query = vueHistoService.Queryable.Where(e => e.Idusager.HasValue && e.Dateelement >= startDate && e.Dateelement <= endDate && (!PermitGates.Any() || PermitGates.Contains(e.Idcircuit.GetValueOrDefault())))
            //        .Select(e => new ReportQuickDTO()
            //        {
            //            Libelle = accessList.Where(s => s.Idcircuit == e.Idcircuit).Select(s => s.Libelle).FirstOrDefault(),
            //            DescriptionCircuit = accessList.Where(s => s.Idcircuit == e.Idcircuit).Select(s => s.Description).FirstOrDefault(),
            //            InOutDate = e.Dateelement,
            //            Key = e.Idusager,
            //            User = userList.FirstOrDefault(s => s.IdUser == e.Idusager)
            //        }).GroupBy(e => e.Key)
            //        .Where(e => e.OrderByDescending(o => o.InOutDate).FirstOrDefault() != null && !string.IsNullOrEmpty(e.OrderByDescending(o => o.InOutDate).FirstOrDefault().Libelle) && e.OrderByDescending(o => o.InOutDate).FirstOrDefault().Libelle.Contains(Contants.Gate_Entry, StringComparison.OrdinalIgnoreCase))
            //    .Select(e => new ReportQuickDTO()
            //    {
            //        DescriptionCircuit = e.Select(s => s.DescriptionCircuit).FirstOrDefault(),
            //        InOutDate = e.Select(s => s.InOutDate).FirstOrDefault(),
            //        Key = Guid.NewGuid(),
            //        User = e.Select(s => s.User).FirstOrDefault() ?? new UserListDTO(),
            //    }).Where(e => e.User != null && !string.IsNullOrEmpty(e.User.IDNumber) && !string.IsNullOrEmpty(e.DescriptionCircuit));
            //    return DataSourceLoader.Load(query, loadOptions);
            //}
            //else
            //{
            //    var query = vueHistoService.Queryable.Where(e => e.Idusager.HasValue && e.Dateelement >= startDate && e.Dateelement <= endDate && (!PermitGates.Any() || PermitGates.Contains(e.Idcircuit.GetValueOrDefault()))).Select(e => new ReportQuickDTO()
            //    {
            //        DescriptionCircuit = accessList.Where(s => s.Idcircuit == e.Idcircuit).Select(s => s.Description).FirstOrDefault(),
            //        InOutDate = e.Dateelement,
            //        Key = Guid.NewGuid(),
            //        User = userList.FirstOrDefault(s => s.IdUser == e.Idusager) ?? new UserListDTO()
            //    });
            //    return DataSourceLoader.Load(query, loadOptions);
            //}
            return DataSourceLoader.Load(new List<UserViewDetailDTO>(), loadOptions);
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

                        ws2 = PrintFormat(ws2, false);
                        ws2.PrinterSettings.Orientation = eOrientation.Portrait;

                        ws2 = TemplateFormat(ws2);

                        Request.Form.TryGetValue("fname", out StringValues title);
                        ws2 = AddHeader(ws2, title, processExcel.Vu, processExcel.Phong);

                        int countCol = ws2.Dimension.Columns;
                        int countRow = ws2.Dimension.Rows;

                        var bytes = package2.GetAsByteArray();
                        var path = Path.Combine(environment.WebRootPath, "temp");
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);
                        var filename = title + ".xlsx";

                        if (processExcel.IsPrint)
                        {
                            filename = title + ".pdf";
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