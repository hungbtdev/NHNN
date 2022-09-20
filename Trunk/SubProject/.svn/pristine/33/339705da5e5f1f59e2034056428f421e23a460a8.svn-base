using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vinorsoft.NHNN.Report.DTO
{
    public class UserViewDetailDTO
    {
        Guid? _id;
        public Guid Id
        {
            get
            {
                if (!_id.HasValue)
                    _id = Guid.NewGuid();

                return _id.Value;
            }
        }

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
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.AccessHistorical_Date), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public DateTime? CheckInOutTime { get; set; }

        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.AccessHistorical_Time), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public string DisplayTime
        {
            get
            {
                return CheckInOutTime.HasValue ? string.Format("{0:HH:mm}", CheckInOutTime.Value) : string.Empty;
            }
        }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.AccessHistorical_DescriptionCircuit), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public string Door { get; set; }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.AccessHistorical_LibelleCircuit), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public string ControllerCode { get; set; }
        public int? DayOfWeek { get; set; }
        public int? Year { get; set; }
        public int? Day { get; set; }
        public int? MONTH { get; set; }
        public int? InOutType { get; set; }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.AccessHistorical_InOut), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public string InOut
        {
            get
            {
                if (InOutType.HasValue)
                {
                    if(InOutType.Value > 0)
                    return Vinorsoft_NHNN_Report_DevEx_DTO_Resource.CheckIn;
                    else return Vinorsoft_NHNN_Report_DevEx_DTO_Resource.CheckOut;
                }
                return string.Empty;
            }
        }

    }
}
