using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Vinorsoft.Core;
using Vinorsoft.Core.App.Attribute;
using Vinorsoft.Core.App.Controllers;
using Vinorsoft.NHNN.Report.DTO;
using Vinorsoft.NHNN.Report.DTO.ReportDTO;
//using Vinorsoft.NHNN.Report.DTO.ReportDTO;
using Vinorsoft.NHNN.Report.Service.Entities;
using Vinorsoft.NHNN.Report.Service.Interface;

namespace Vinorsoft.NHNN.Report.App.Areas.Report.Controllers
{
    [Area("Report")]
    [Description("Báo cáo ra vào")]
    [VinorsoftAuthorize2(permission: new string[] { CoreConstants.View })]
    public class ReportCheckInOutController : ReportShareController
    {
        readonly ICheckInOutService checkInOutService;
        readonly IUserListService userListService;
        readonly IMapper mapper;
        public ReportCheckInOutController(IServiceProvider serviceProvider, IMapper mapper) : base(serviceProvider)
        {
            checkInOutService = serviceProvider.GetRequiredService<ICheckInOutService>();
            userListService = serviceProvider.GetRequiredService<IUserListService>();
            this.mapper = mapper;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions, int month, int year)
        {

            var query = checkInOutService.GetVwLogAccesses().Where(e =>
            e.CheckInOutTime.Value.Month == month &&
            e.CheckInOutTime.Value.Year == year&&
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
               .Select(e => new WorkingTimeRowDTO()
               {

                   EmployeeNumber = e.Key.EmployeeNumber,
                   FullName = e.Key.FullName,
                   DeptName=e.Key.DeptName,
                   ParentDeptName=e.Key.ParentDeptName,
                   JobtitleName=e.Key.JobtitleName,
                   VwLogAccess = e.Select(c => new VwLogAccessDTO()
                   {
                       CheckInOutTime = c.CheckInOutTime,
                       Door = c.Door,
                       Day = c.Day,
                       InOutType = c.InOutType,
                       DayOfWeek=c.DayOfWeek,
                       EmployeeNumber=c.EmployeeNumber,
                       Month=c.Month,
                       Year=c.Year,
                   }).ToList(),
               }).ToList();
            return DataSourceLoader.Load(query, loadOptions);
        }

        [HttpGet]
        public IActionResult Index(int? month, int? year)
        {
            SearchReportCheckInOutDTO searchReportCheckIn = new SearchReportCheckInOutDTO
            {
                Month = month ?? DateTime.Now.Month,
                Year = year ?? DateTime.Now.Year
            };
            return View(searchReportCheckIn);
        }

    }
}