using System;
using System.ComponentModel.DataAnnotations;

namespace Vinorsoft.NHNN.Report.DTO
{
    public class UserViewListDTO
    {
       
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.UserList_IDNumber), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public string EmployeeNumber { get; set; }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.UserList_Name), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public string FullName { get; set; }
        public string ParentDeptId { get; set; }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.UserList_Cuc), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public string ParentDeptName { get; set; }
        public string DeptId { get; set; }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.UserConfig_Department), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public string DeptName { get; set; }
        public string JobtitleId { get; set; }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.UserConfig_JobTitle), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public string JobtitleName { get; set; }
        public int? IsExcept { get; set; }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.AccessHistorical_IsNoCaculate), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public bool IsNoCaculate
        {
            get
            {
                return (IsExcept.HasValue && IsExcept.Value > 0) ? true : false;
            }
        }

        public DateTime? CheckInOutTime { get; set; }
        public string Door { get; set; }
        public string ControllerCode { get; set; }
        public int? DayOfWeek { get; set; }
        public int? Year { get; set; }
        public int? Day { get; set; }
        public int? MONTH { get; set; }
        public int? InOutType { get; set; }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.UserConfig_IsNoCaculate), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public bool IsNoLate { get; set; }


    }
}
