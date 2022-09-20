using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vinorsoft.NHNN.Report.DTO
{
    public class ReportQuickDTO 
    {
        public object Key { set; get; }
        public UserListDTO User { set; get; }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.ReportQuickDTO_DescriptionCircuit), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public string DescriptionCircuit { set; get; }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.ReportQuickDTO_InOutDate), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public DateTime InOutDate { set; get; }

        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.ReportQuickDTO_InOutTime), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public string InOutTime {
            get
            {
                return string.Format("{0:HH:mm}", InOutDate);
            }
        }

        public string Libelle { set; get; }
    }
}
