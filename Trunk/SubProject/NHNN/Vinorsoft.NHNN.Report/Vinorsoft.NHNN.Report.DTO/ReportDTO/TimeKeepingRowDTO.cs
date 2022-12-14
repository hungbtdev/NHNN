using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Vinorsoft.NHNN.Report.DTO.ReportDTO
{
   public class TimeKeepingRowDTO
    {
        public TimeKeepingRowDTO()
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

        private TimeKeepingDTO GetWorkingTime(int day)
        {
            var checkInTime = VwLogAccess.OrderBy(e => e.CheckInOutTime).FirstOrDefault(e => e.CheckInOutTime.Value.Day == day && e.InOutType > 0);
            var checkOutTime = VwLogAccess.OrderByDescending(e => e.CheckInOutTime).FirstOrDefault(e => e.CheckInOutTime.Value.Day == day && e.InOutType <= 0);
            return new TimeKeepingDTO()
            {
                CheckInTime = checkInTime?.CheckInOutTime,
                CheckOutTime = checkOutTime?.CheckInOutTime,
            };
        }

        public TimeKeepingDTO _1
        {
            get
            {
                return GetWorkingTime(1);
            }
        }

        public TimeKeepingDTO _2
        {
            get
            {
                return GetWorkingTime(2);
            }
        }

        public TimeKeepingDTO _3
        {
            get
            {
                return GetWorkingTime(3);
            }
        }

        public TimeKeepingDTO _4
        {
            get
            {
                return GetWorkingTime(4);
            }
        }

        public TimeKeepingDTO _5
        {
            get
            {
                return GetWorkingTime(5);
            }
        }

        public TimeKeepingDTO _6
        {
            get
            {
                return GetWorkingTime(6);
            }
        }

        public TimeKeepingDTO _7
        {
            get
            {
                return GetWorkingTime(7);
            }
        }

        public TimeKeepingDTO _8
        {
            get
            {
                return GetWorkingTime(8);
            }
        }

        public TimeKeepingDTO _9
        {
            get
            {
                return GetWorkingTime(9);
            }
        }

        public TimeKeepingDTO _10
        {
            get
            {
                return GetWorkingTime(10);
            }
        }

        public TimeKeepingDTO _11
        {
            get
            {
                return GetWorkingTime(11);
            }
        }

        public TimeKeepingDTO _12
        {
            get
            {
                return GetWorkingTime(12);
            }
        }

        public TimeKeepingDTO _13
        {
            get
            {
                return GetWorkingTime(13);
            }
        }

        public TimeKeepingDTO _14
        {
            get
            {
                return GetWorkingTime(14);
            }
        }

        public TimeKeepingDTO _15
        {
            get
            {
                return GetWorkingTime(15);
            }
        }

        public TimeKeepingDTO _16
        {
            get
            {
                return GetWorkingTime(16);
            }
        }

        public TimeKeepingDTO _17
        {
            get
            {
                return GetWorkingTime(17);
            }
        }

        public TimeKeepingDTO _18
        {
            get
            {
                return GetWorkingTime(18);
            }
        }

        public TimeKeepingDTO _19
        {
            get
            {
                return GetWorkingTime(19);
            }
        }

        public TimeKeepingDTO _20
        {
            get
            {
                return GetWorkingTime(20);
            }
        }

        public TimeKeepingDTO _21
        {
            get
            {
                return GetWorkingTime(21);
            }
        }

        public TimeKeepingDTO _22
        {
            get
            {
                return GetWorkingTime(22);
            }
        }

        public TimeKeepingDTO _23
        {
            get
            {
                return GetWorkingTime(23);
            }
        }

        public TimeKeepingDTO _24
        {
            get
            {
                return GetWorkingTime(24);
            }
        }

        public TimeKeepingDTO _25
        {
            get
            {
                return GetWorkingTime(25);
            }
        }

        public TimeKeepingDTO _26
        {
            get
            {
                return GetWorkingTime(26);
            }
        }

        public TimeKeepingDTO _27
        {
            get
            {
                return GetWorkingTime(27);
            }
        }

        public TimeKeepingDTO _28
        {
            get
            {
                return GetWorkingTime(28);
            }
        }

        public TimeKeepingDTO _29
        {
            get
            {
                return GetWorkingTime(29);
            }
        }

        public TimeKeepingDTO _30
        {
            get
            {
                return GetWorkingTime(30);
            }
        }

        public TimeKeepingDTO _31
        {
            get
            {
                return GetWorkingTime(31);
            }
        }

        public int WD_Total_Value
        {
            get
            {
                IList<TimeKeepingDTO> sums = new List<TimeKeepingDTO>()
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

                var totalTime = sums.Where(e => e != null && e.TotalTime.HasValue).Sum(e => e.TotalTime.Value.Ticks);
                int temp = (int)(new TimeSpan(totalTime).TotalSeconds / 60);
                return temp;            }
        }
        public string WD_Total
        {
            get
            {
                int temp = WD_Total_Value;
                int totalHr = temp / 60;
                int totalMinute = temp % 60;

                return $"{totalHr.ToString("D2")}:{totalMinute.ToString("D2")}";
            }
        }
    }
}
