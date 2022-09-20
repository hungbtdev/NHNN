using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vinorsoft.NHNN.Report.DTO.ReportDTO
{
    public class WorkingTimeRowDTO
    {

        public WorkingTimeRowDTO()
        {
            VwLogAccess = new List<VwLogAccessDTO>();
        }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.UserList_IDNumber), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public string EmployeeNumber { set; get; }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.UserList_Name), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public string FullName { set; get; }
        public string Type { set; get; }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.UserList_Cuc), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public string ParentDeptName { set; get; }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.UserList_Phong), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public string DeptName { set; get; }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.UserList_ChucVu), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public string JobtitleName { set; get; }
        public IList<VwLogAccessDTO> VwLogAccess { set; get; }
        private WorkingTimeDTO GetWorkingTime(int day)
        {
            var checkInTime = VwLogAccess.OrderBy(e => e.CheckInOutTime).FirstOrDefault(e => e.CheckInOutTime.Value.Day == day && e.InOutType > 0);
            var checkOutTime = VwLogAccess.OrderByDescending(e => e.CheckInOutTime).FirstOrDefault(e => e.CheckInOutTime.Value.Day == day && e.InOutType <= 0);
            return new WorkingTimeDTO()
            {
                CheckInTime = checkInTime?.CheckInOutTime,
                CheckOutTime = checkOutTime?.CheckInOutTime,
                LimitOfMinute = LimitOfMinute
            };
        }

        public WorkingTimeDTO _1
        {
            get
            {
                return GetWorkingTime(1);
            }
        }

        public WorkingTimeDTO _2
        {
            get
            {
                return GetWorkingTime(2);
            }
        }

        public WorkingTimeDTO _3
        {
            get
            {
                return GetWorkingTime(3);
            }
        }

        public WorkingTimeDTO _4
        {
            get
            {
                return GetWorkingTime(4);
            }
        }

        public WorkingTimeDTO _5
        {
            get
            {
                return GetWorkingTime(5);
            }
        }

        public WorkingTimeDTO _6
        {
            get
            {
                return GetWorkingTime(6);
            }
        }

        public WorkingTimeDTO _7
        {
            get
            {
                return GetWorkingTime(7);
            }
        }

        public WorkingTimeDTO _8
        {
            get
            {
                return GetWorkingTime(8);
            }
        }

        public WorkingTimeDTO _9
        {
            get
            {
                return GetWorkingTime(9);
            }
        }

        public WorkingTimeDTO _10
        {
            get
            {
                return GetWorkingTime(10);
            }
        }

        public WorkingTimeDTO _11
        {
            get
            {
                return GetWorkingTime(11);
            }
        }

        public WorkingTimeDTO _12
        {
            get
            {
                return GetWorkingTime(12);
            }
        }

        public WorkingTimeDTO _13
        {
            get
            {
                return GetWorkingTime(13);
            }
        }

        public WorkingTimeDTO _14
        {
            get
            {
                return GetWorkingTime(14);
            }
        }

        public WorkingTimeDTO _15
        {
            get
            {
                return GetWorkingTime(15);
            }
        }

        public WorkingTimeDTO _16
        {
            get
            {
                return GetWorkingTime(16);
            }
        }

        public WorkingTimeDTO _17
        {
            get
            {
                return GetWorkingTime(17);
            }
        }

        public WorkingTimeDTO _18
        {
            get
            {
                return GetWorkingTime(18);
            }
        }

        public WorkingTimeDTO _19
        {
            get
            {
                return GetWorkingTime(19);
            }
        }

        public WorkingTimeDTO _20
        {
            get
            {
                return GetWorkingTime(20);
            }
        }

        public WorkingTimeDTO _21
        {
            get
            {
                return GetWorkingTime(21);
            }
        }

        public WorkingTimeDTO _22
        {
            get
            {
                return GetWorkingTime(22);
            }
        }

        public WorkingTimeDTO _23
        {
            get
            {
                return GetWorkingTime(23);
            }
        }

        public WorkingTimeDTO _24
        {
            get
            {
                return GetWorkingTime(24);
            }
        }

        public WorkingTimeDTO _25
        {
            get
            {
                return GetWorkingTime(25);
            }
        }

        public WorkingTimeDTO _26
        {
            get
            {
                return GetWorkingTime(26);
            }
        }

        public WorkingTimeDTO _27
        {
            get
            {
                return GetWorkingTime(27);
            }
        }

        public WorkingTimeDTO _28
        {
            get
            {
                return GetWorkingTime(28);
            }
        }

        public WorkingTimeDTO _29
        {
            get
            {
                return GetWorkingTime(29);
            }
        }

        public WorkingTimeDTO _30
        {
            get
            {
                return GetWorkingTime(30);
            }
        }

        public WorkingTimeDTO _31
        {
            get
            {
                return GetWorkingTime(31);
            }
        }

        public int LimitOfMinute { set; get; }

        public string WD_Total
        {
            get
            {
                IList<WorkingTimeDTO> sums = new List<WorkingTimeDTO>()
                {
                    GetWorkingTime(1),
                    GetWorkingTime(2),
                    GetWorkingTime(3),
                    GetWorkingTime(4),
                    GetWorkingTime(5),
                    GetWorkingTime(6),
                    GetWorkingTime(7),
                    GetWorkingTime(8),
                    GetWorkingTime(9),
                    GetWorkingTime(10),
                    GetWorkingTime(11),
                    GetWorkingTime(12),
                    GetWorkingTime(13),
                    GetWorkingTime(14),
                    GetWorkingTime(15),
                    GetWorkingTime(16),
                    GetWorkingTime(17),
                    GetWorkingTime(18),
                    GetWorkingTime(19),
                    GetWorkingTime(20),
                    GetWorkingTime(21),
                    GetWorkingTime(22),
                    GetWorkingTime(23),
                    GetWorkingTime(24),
                    GetWorkingTime(25),
                    GetWorkingTime(26),
                    GetWorkingTime(27),
                    GetWorkingTime(28),
                    GetWorkingTime(29),
                    GetWorkingTime(30),
                    GetWorkingTime(31)
                };

                var late = sums.Where(e => e != null && e.TotalLateTime.HasValue && e.TotalLateTime.Value.TotalMinutes > 0).Sum(e => e.TotalLateTime.Value.Ticks);
                var soon = sums.Where(e => e != null && e.TotalSoonTime.HasValue && e.TotalSoonTime.Value.TotalMinutes > 0).Sum(e => e.TotalSoonTime.Value.Ticks);

                string result = string.Empty;

                if (late >= 10000)
                {
                    result+= $"DM:{new TimeSpan(late).ToString("hh\\:mm")}\n";
                }

                if (soon >= 10000)
                {
                    result+= $"VS:{new TimeSpan(soon).ToString("hh\\:mm")}";
                }

                return result;
            }
        }
    }
}
