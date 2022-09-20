using KTApps.Core.LoggingService.Entities;
using KTApps.Core.LoggingService.Interface;
using Microsoft.EntityFrameworkCore;

namespace KTApps.Core.LoggingService
{
    public class LoggingDbContext : DbContext, ILoggingDbContext
    {
        public LoggingDbContext(DbContextOptions<LoggingDbContext> options) : base(options)
        {

        }

        public DbSet<CoreApiLogItems> CoreApiLogItems { get; set; }
    }
}
