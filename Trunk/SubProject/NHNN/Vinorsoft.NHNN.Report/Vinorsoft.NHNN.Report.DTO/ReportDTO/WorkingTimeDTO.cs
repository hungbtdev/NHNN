using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vinorsoft.NHNN.Report.DTO.ReportDTO
{
    public class WorkingTimeDTO
    {
        public int WorkingStartHr = 7;
        public int WorkingStartMinute = 30;

        public int WorkingEndHr = 17;
        public int WorkingEndMinute = 00;

        public DateTime? CheckInTime { set; get; }
        public DateTime? CheckOutTime { set; get; }
        public int LimitOfMinute { set; get; }

        //Về sớm
        public TimeSpan? TotalSoonTime
        {
            get
            {
                if (CheckOutTime.HasValue && CheckOutTime.Value.Date.DayOfWeek != DayOfWeek.Saturday && CheckOutTime.Value.Date.DayOfWeek != DayOfWeek.Sunday)
                    return new TimeSpan(WorkingEndHr, WorkingEndMinute, 0) - new TimeSpan(CheckOutTime.Value.Hour, CheckOutTime.Value.Minute, CheckOutTime.Value.Second) - new TimeSpan(0, LimitOfMinute, 0);
                return null;
            }
        }

        // Đi trễ
        public TimeSpan? TotalLateTime
        {
            get
            {
                if (CheckInTime.HasValue && CheckInTime.Value.Date.DayOfWeek != DayOfWeek.Saturday && CheckInTime.Value.Date.DayOfWeek != DayOfWeek.Sunday)
                    return new TimeSpan(CheckInTime.Value.Hour, CheckInTime.Value.Minute, CheckInTime.Value.Second) - new TimeSpan(WorkingStartHr, WorkingStartMinute, 0) - new TimeSpan(0, LimitOfMinute, 0);
                return null;
            }
        }

        public string Summary
        {
            get
            {
                string result = string.Empty;
                if (TotalLateTime.HasValue && TotalLateTime.Value.TotalMinutes >= 1)
                {
                    int temp = (int)(TotalLateTime.Value.TotalSeconds / 60);
                    int totalHr = temp / 60;
                    int totalMinute = temp % 60;
                    result += $"DM: {totalHr.ToString("D2")}:{totalMinute.ToString("D2")}\n";
                }
                if (TotalSoonTime.HasValue && TotalSoonTime.Value.TotalMinutes >= 1)
                {
                    int temp = (int)(TotalSoonTime.Value.TotalSeconds / 60);
                    int totalHr = temp / 60;
                    int totalMinute = temp % 60;
                    result += $"VS: {totalHr.ToString("D2")}:{totalMinute.ToString("D2")}";
                }
                return result;
            }
        }

        public string SummaryCheckInOut
        {
            get
            {
                string result = string.Empty;
                if (CheckInTime.HasValue)
                    result += $"V: {CheckInTime?.ToString("HH:mm")}<br>";

                if (CheckOutTime.HasValue)
                    result += $"R: {CheckOutTime?.ToString("HH:mm")}";

                return result;
            }
        }
    }
}
