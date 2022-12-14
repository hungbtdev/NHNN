using System;
using System.Collections.Generic;
using System.Text;

namespace Vinorsoft.NHNN.Report.DTO.ReportDTO
{
    public class OverTimeDTO
    {
        public int WorkingEndHr = 17;
        public int WorkingEndMinute = 0;
        public DateTime? CheckOutTime { set; get; }
        public DateTime? CheckInTime { set; get; }

        //Giờ làm thêm
        public TimeSpan? TotalOverTime
        {
            get
            {
                //Nếu là t7/chủ nhật thì tính full time
                if (CheckOutTime.HasValue && (
                    CheckOutTime.Value.DayOfWeek == DayOfWeek.Saturday ||
                    CheckOutTime.Value.DayOfWeek == DayOfWeek.Sunday
                    ))
                {
                    if (CheckInTime.HasValue)
                    {
                        return new TimeSpan(CheckOutTime.Value.Hour, CheckOutTime.Value.Minute, CheckOutTime.Value.Second) - new TimeSpan(CheckInTime.Value.Hour, CheckInTime.Value.Minute, 0);
                    }

                    return null;
                }

                if (CheckOutTime.HasValue)
                    return new TimeSpan(CheckOutTime.Value.Hour, CheckOutTime.Value.Minute, CheckOutTime.Value.Second) - new TimeSpan(WorkingEndHr, WorkingEndMinute, 0);
                return null;
            }
        }


        public string Summary
        {
            get
            {
                if (TotalOverTime.HasValue && TotalOverTime.Value.TotalSeconds > 0)
                {
                    int temp = (int)(TotalOverTime.Value.TotalSeconds / 60);
                    int totalHr = temp / 60;
                    int totalMinute = temp % 60;
                    return $"{totalHr.ToString("D2")}:{totalMinute.ToString("D2")}";
                }
                return string.Empty;
            }
        }
    }
}
