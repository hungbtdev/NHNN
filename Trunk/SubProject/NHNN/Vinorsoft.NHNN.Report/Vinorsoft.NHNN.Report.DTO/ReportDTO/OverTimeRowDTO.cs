using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Vinorsoft.NHNN.Report.DTO.ReportDTO
{
   public class OverTimeRowDTO
    {
        public OverTimeRowDTO()
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

        private OverTimeDTO GetWorkingTime(int day)
        {
            var checkInTime = VwLogAccess.OrderBy(e => e.CheckInOutTime).FirstOrDefault(e => e.CheckInOutTime.Value.Day == day && e.InOutType > 0);
            var checkOutTime = VwLogAccess.OrderByDescending(e => e.CheckInOutTime).FirstOrDefault(e => e.CheckInOutTime.Value.Day == day && e.InOutType <= 0);
            return new OverTimeDTO()
            {
                CheckInTime = checkInTime?.CheckInOutTime,
                CheckOutTime = checkOutTime?.CheckInOutTime,
            };
        }

        public OverTimeDTO _1
        {
            get
            {
                return GetWorkingTime(1);
            }
        }

        public OverTimeDTO _2
        {
            get
            {
                return GetWorkingTime(2);
            }
        }

        public OverTimeDTO _3
        {
            get
            {
                return GetWorkingTime(3);
            }
        }

        public OverTimeDTO _4
        {
            get
            {
                return GetWorkingTime(4);
            }
        }

        public OverTimeDTO _5
        {
            get
            {
                return GetWorkingTime(5);
            }
        }

        public OverTimeDTO _6
        {
            get
            {
                return GetWorkingTime(6);
            }
        }

        public OverTimeDTO _7
        {
            get
            {
                return GetWorkingTime(7);
            }
        }

        public OverTimeDTO _8
        {
            get
            {
                return GetWorkingTime(8);
            }
        }

        public OverTimeDTO _9
        {
            get
            {
                return GetWorkingTime(9);
            }
        }

        public OverTimeDTO _10
        {
            get
            {
                return GetWorkingTime(10);
            }
        }

        public OverTimeDTO _11
        {
            get
            {
                return GetWorkingTime(11);
            }
        }

        public OverTimeDTO _12
        {
            get
            {
                return GetWorkingTime(12);
            }
        }

        public OverTimeDTO _13
        {
            get
            {
                return GetWorkingTime(13);
            }
        }

        public OverTimeDTO _14
        {
            get
            {
                return GetWorkingTime(14);
            }
        }

        public OverTimeDTO _15
        {
            get
            {
                return GetWorkingTime(15);
            }
        }

        public OverTimeDTO _16
        {
            get
            {
                return GetWorkingTime(16);
            }
        }

        public OverTimeDTO _17
        {
            get
            {
                return GetWorkingTime(17);
            }
        }

        public OverTimeDTO _18
        {
            get
            {
                return GetWorkingTime(18);
            }
        }

        public OverTimeDTO _19
        {
            get
            {
                return GetWorkingTime(19);
            }
        }

        public OverTimeDTO _20
        {
            get
            {
                return GetWorkingTime(20);
            }
        }

        public OverTimeDTO _21
        {
            get
            {
                return GetWorkingTime(21);
            }
        }

        public OverTimeDTO _22
        {
            get
            {
                return GetWorkingTime(22);
            }
        }

        public OverTimeDTO _23
        {
            get
            {
                return GetWorkingTime(23);
            }
        }

        public OverTimeDTO _24
        {
            get
            {
                return GetWorkingTime(24);
            }
        }

        public OverTimeDTO _25
        {
            get
            {
                return GetWorkingTime(25);
            }
        }

        public OverTimeDTO _26
        {
            get
            {
                return GetWorkingTime(26);
            }
        }

        public OverTimeDTO _27
        {
            get
            {
                return GetWorkingTime(27);
            }
        }

        public OverTimeDTO _28
        {
            get
            {
                return GetWorkingTime(28);
            }
        }

        public OverTimeDTO _29
        {
            get
            {
                return GetWorkingTime(29);
            }
        }

        public OverTimeDTO _30
        {
            get
            {
                return GetWorkingTime(30);
            }
        }

        public OverTimeDTO _31
        {
            get
            {
                return GetWorkingTime(31);
            }
        }

        public string WD_Total
        {
            get
            {
                IList<OverTimeDTO> sums = new List<OverTimeDTO>()
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

                var total = sums.Where(e => e != null && e.TotalOverTime.HasValue && e.TotalOverTime.Value.TotalMinutes > 60).Sum(e => e.TotalOverTime.Value.Ticks);

                string result = string.Empty;

                if (total >= 10000)
                {
                    result += $"{new TimeSpan(total).ToString("hh\\:mm")}\n";

                }

                return result;
            }
        }
    }
}
