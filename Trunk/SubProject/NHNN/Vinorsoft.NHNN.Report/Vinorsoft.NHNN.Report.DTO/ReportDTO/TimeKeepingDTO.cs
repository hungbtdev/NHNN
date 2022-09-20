using System;
using System.Collections.Generic;
using System.Text;

namespace Vinorsoft.NHNN.Report.DTO.ReportDTO
{
    public class TimeKeepingDTO
    {
        public DateTime? CheckInTime { set; get; }
        public DateTime? CheckOutTime { set; get; }

        //Về sớm
        public TimeSpan? TotalTime
        {
            get
            {
                TimeSpan start;
                TimeSpan end;

                if (CheckInTime.HasValue && CheckOutTime.HasValue && CheckInTime.Value <= CheckOutTime.Value)
                {
                    start = new TimeSpan(CheckInTime.Value.Hour, CheckInTime.Value.Minute, CheckInTime.Value.Second);
                    end = new TimeSpan(CheckOutTime.Value.Hour, CheckOutTime.Value.Minute, CheckOutTime.Value.Second);
                    if (start < new TimeSpan(17, 0, 0))
                    {
                        if (start < new TimeSpan(7, 30, 0))
                            start = new TimeSpan(7, 30, 0);

                        if (end > new TimeSpan(17, 0, 0))
                            end = new TimeSpan(17, 0, 0);

                        if (start < new TimeSpan(12, 0, 0) && end < new TimeSpan(12, 0, 0) ||
                            (start > new TimeSpan(13, 0, 0) && end > new TimeSpan(13, 0, 0))
                            )
                        {
                            return end.Subtract(start);
                        }
                        return end.Subtract(start).Subtract(new TimeSpan(1, 30, 0));
                    }
                }
                return null;
            }
        }
        public string Summary
        {
            get
            {
                if (TotalTime.HasValue && TotalTime.Value.TotalSeconds > 0)
                {
                    int temp = (int)(TotalTime.Value.TotalSeconds / 60);
                    int totalHr = temp / 60;
                    int totalMinute = temp % 60;
                    return $"{totalHr.ToString("D2")}:{totalMinute.ToString("D2")}";
                }
                return string.Empty;
            }
        }
    }
}
