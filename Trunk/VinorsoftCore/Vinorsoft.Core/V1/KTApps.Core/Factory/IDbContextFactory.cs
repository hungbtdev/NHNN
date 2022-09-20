using KTApps.Core.EF;

namespace KTApps.Core.Factory
{
    public interface IDbContextFactory
    {
        string ConnectionString { get; set; }
        ICoreDbContext Create();
    }
}
