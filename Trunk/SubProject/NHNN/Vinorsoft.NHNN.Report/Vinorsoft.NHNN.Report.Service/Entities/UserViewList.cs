using System;
using System.Collections.Generic;
using System.Text;

namespace Vinorsoft.NHNN.Report.Service.Entities
{
    public class UserViewList
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

        public int? IsExcept { get; set; }

    }
}
