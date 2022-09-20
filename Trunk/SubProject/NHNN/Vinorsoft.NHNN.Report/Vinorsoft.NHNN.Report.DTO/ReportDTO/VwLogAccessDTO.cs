using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Vinorsoft.NHNN.Report.DTO.ReportDTO
{
    public class VwLogAccessDTO
    {
        public string EmployeeNumber { get; set; }
        public string FullName { set; get; }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.AccessHistorical_Date), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
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
