using System;
using System.Collections.Generic;
using System.Text;

namespace Vinorsoft.NHNN.Report.Service.Entities
{
    public class UserViewDetail
    {
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeNumber { get; set; }
        /// <summary>
        /// Tên
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Mã cục/vụ
        /// </summary>
        public string ParentDeptId { get; set; }
        /// <summary>
        /// Tên cục/vụ
        /// </summary>
        public string ParentDeptName { get; set; }
        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public string DeptId { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// Mã chức vụ
        /// </summary>
        public string JobtitleId { get; set; }
        /// <summary>
        /// Tên chức vụ
        /// </summary>
        public string JobtitleName { get; set; }

        public DateTime? CheckInOutTime { get; set; }
        public string Door { get; set; }
        public string ControllerCode { get; set; }
        public int? DayOfWeek { get; set; }
        public int? Year { get; set; }
        public int? Day { get; set; }
        public int? MONTH { get; set; }
        public int? InOutType { get; set; }

        public int? IsExcept { get; set; }

        public IList<UserViewDetail> UserViewDetails { get; set; }
    }

    public class QuickReportView
    {
        public string EmployeeNumber { get; set; }
        public string FullName { get; set; }
        public string ParentDeptName { get; set; }
        public string DeptName { get; set; }
        public string JobtitleName { get; set; }
        public DateTime? CheckInOutTime { get; set; }
    }

}
