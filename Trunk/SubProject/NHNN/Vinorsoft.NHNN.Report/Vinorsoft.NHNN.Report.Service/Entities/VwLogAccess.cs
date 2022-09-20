using System;
using System.Collections.Generic;
using System.Text;

namespace Vinorsoft.NHNN.Report.Service.Entities
{
   public  class VwLogAccess
    {
        
        public string EmployeeNumber { get; set; }
        public string FullName { set; get; }
        public DateTime? CheckInOutTime { set; get; }
        public string Door { set; get; }
        public string ControllerCode { set; get; }
        public string ParentDeptId { set; get; }
        public string ParentDeptName { set; get; }
        public string DeptId { set; get; }
        public string DeptName { set; get; }
        public string JobtitleId { set; get; }
        public string JobtitleName { set; get; }
        public int? IsExcept { set; get; }
        public int? DayOfWeek { set; get; }
        public int? Year { set; get; }
        public int? Day { set; get; }
        public int? Month { set; get; }
        public int? InOutType { set; get; }
    }
}
