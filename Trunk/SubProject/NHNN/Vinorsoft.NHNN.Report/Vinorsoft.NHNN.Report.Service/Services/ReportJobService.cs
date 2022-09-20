using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Vinorsoft.NHNN.Report.Service.Interface;

namespace Vinorsoft.NHNN.Report.Service
{
    public class ReportJobService : IReportJobService
    {
        readonly INHNNDbContext dbContext;
        readonly ILogger<ReportJobService> logger;
        public ReportJobService(INHNNDbContext dbContext, ILogger<ReportJobService> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public void SyncData(DateTime startDate)
        {
            try
            {
                var commandText = "EXEC [dbo].[sp_insert_acccess_historical] @start_date, @end_date";
                int result = dbContext.Database.ExecuteSqlCommand(commandText, new SqlParameter[] {
                new SqlParameter("@start_date", startDate.Date),
                new SqlParameter("@end_date", startDate.Date.AddDays(1).AddSeconds(-1))
            });
                logger.LogInformation("sp_insert_acccess_historical = " + result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex, new string[] { });
            }

            try
            {
                var commandText = "EXEC [dbo].[sp_insert_user] @start_date, @end_date";
                int result = dbContext.Database.ExecuteSqlCommand(commandText, new SqlParameter[] {
                new SqlParameter("@start_date", startDate.Date),
                new SqlParameter("@end_date", startDate.Date.AddDays(1).AddSeconds(-1))

                //new SqlParameter("@start_date", new DateTime(2018,1,1)),
                //new SqlParameter("@end_date", new DateTime(2020,02,11))
            });
                logger.LogInformation("sp_insert_user = " + result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex, new string[] { });
            }
        }
    }
}
