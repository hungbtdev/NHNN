using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vinorsoft.NHNN.Report.DTO
{
    public class SearchReportQuickDTO
    {
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.SearchReportQuick_SearchDate), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public DateTime? SearchDate { set; get; }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.SearchReportQuick_StartHour), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public int? StartHour { set; get; }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.SearchReportQuick_EndHour), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public int? EndHour { set; get; }

        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.SearchReportQuick_Inside), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public bool Inside { set; get; }
        

        public DateTime? StartDate {
            get
            {
                if (SearchDate.HasValue)
                {
                    return new DateTime(SearchDate.Value.Year, SearchDate.Value.Month, SearchDate.Value.Day, StartHour ?? 0, 0, 0);
                }
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, StartHour ?? 0, 0, 0);
            }
        }
        public DateTime? EndDate {
            get
            {
                if (SearchDate.HasValue)
                {
                    return new DateTime(SearchDate.Value.Year, SearchDate.Value.Month, SearchDate.Value.Day, EndHour ?? 23, 59, 59);
                }
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, EndHour ?? 23, 59, 59);
            }
        }

    }
}
