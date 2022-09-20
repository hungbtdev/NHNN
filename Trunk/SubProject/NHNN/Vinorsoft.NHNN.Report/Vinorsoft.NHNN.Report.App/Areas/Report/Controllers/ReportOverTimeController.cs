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
using Vinorsoft.Core.Interface;
using Vinorsoft.NHNN.Report.DTO;
using Vinorsoft.NHNN.Report.DTO.ReportDTO;
using Vinorsoft.NHNN.Report.Service.Interface;

namespace Vinorsoft.NHNN.Report.App.Areas.Report.Controllers
{
    [Area("Report")]
    [Description("Báo cáo làm thêm giờ")]
    [VinorsoftAuthorize2(permission: new string[] { CoreConstants.View })]
    public class ReportOverTimeController : ReportShareController
    {
        readonly IOverTimeService overTimeService;
        readonly IUserListService userListService;
        readonly ICoreSystemConfigService coreSystemConfigService;
        readonly ICheckInOutService checkInOutService;


        public ReportOverTimeController(IServiceProvider serviceProvider, IMapper mapper) : base(serviceProvider)
        {
            overTimeService = serviceProvider.GetRequiredService<IOverTimeService>();
            userListService = serviceProvider.GetRequiredService<IUserListService>();
            coreSystemConfigService = serviceProvider.GetRequiredService<ICoreSystemConfigService>();
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
        public object Get(DataSourceLoadOptions loadOptions, int month, int year)
        {
            #region
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
            //var query = overTimeService.Queryable
            //    .Where(e => e.Dat.Month == month && e.Dat.Year == year && !string.IsNullOrEmpty(e.Codelogique) && !e.Codelogique.StartsWith(UserListDTO.Prefix_THE, StringComparison.OrdinalIgnoreCase))
            //    .GroupBy(e => new
            //    {
            //        e.IdUsager
            //    }).Select(e => new ReportOverTimeDTO()
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

            var query = checkInOutService.GetVwLogAccesses().Where(e => e.CheckInOutTime.Value.Month == month && e.CheckInOutTime.Value.Year == year &&
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
              .Select(e => new OverTimeRowDTO()
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

        [HttpGet]
        public IActionResult Index(int? month, int? year)
        {
            SearchReportOverTimeDTO searchReportCheckIn = new SearchReportOverTimeDTO
            {
                Month = month ?? DateTime.Now.Month,
                Year = year ?? DateTime.Now.Year
            };
            return View(searchReportCheckIn);
        }
    }
}