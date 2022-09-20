using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Vinorsoft.NHNN.Report.DTO
{
    public class SearchReportBaseDTO
    {
        public SearchReportBaseDTO()
        {

        }

        public SearchReportBaseDTO(int month, int year)
        {
            Year = year;
            Month = month;
        }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.SearchReportCheckInOut_Month), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public int? Month { set; get; }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.SearchReportCheckInOut_Year), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public int? Year { set; get; }
        
        public bool Show_31
        {
            get
            {
                var total = DateTime.DaysInMonth(Year.Value, Month.Value);
                return total >= 31;
            }
        }
        public bool Show_30
        {
            get
            {
                var total = DateTime.DaysInMonth(Year.Value, Month.Value);
                return total >= 30;
            }
        }
        public bool Show_29
        {
            get
            {
                var total = DateTime.DaysInMonth(Year.Value, Month.Value);
                return total >= 29;
            }
        }
        public bool Show_28
        {
            get
            {
                var total = DateTime.DaysInMonth(Year.Value, Month.Value);
                return total >= 28;
            }
        }

        public IList<string> DayOfWeek
        {
            get
            {
                var result = new List<string>();
                if (Month >0 && Year > 0)
                {
                    var total = DateTime.DaysInMonth(Year.Value, Month.Value);
                    for (int day = 1; day <= total; day++)
                    {
                        var currentDate = new DateTime(Year.Value, Month.Value, day, 0, 0, 0);
                        if (currentDate.DayOfWeek == System.DayOfWeek.Sunday)
                            result.Add("CN");
                        else
                            result.Add("T." + (((int)currentDate.DayOfWeek) + 1));
                    }
                }
                return result;
            }
        }

        public string GetDayOfWeek(int index)
        {
            if (DayOfWeek.Count > index)
            {
                return DayOfWeek[index];
            }
            return string.Empty;
        }

        public string GetHighLightCss(int index)
        {
            if (DayOfWeek.Count > index)
            {
                if (DayOfWeek[index] == "CN" || DayOfWeek[index] == "T.7")
                    return "highlight";
            }
            return string.Empty;
        }
    }
}
