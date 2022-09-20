using KTApps.ShareService.Entities;
using KTApps.ShareService.Interface;
using Microsoft.EntityFrameworkCore;

namespace KTApps.ShareService
{
    public class CoreUploadDbContext : DbContext, ICoreUploadDbContext
    {
        public CoreUploadDbContext(DbContextOptions<CoreUploadDbContext> options) : base(options)
        {
        }

        public DbSet<CoreUploadFiles> CoreUploadFiles { set; get; }
    }
}
