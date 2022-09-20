using System;
using System.Linq;
using Vinorsoft.Core.Entities.Media;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core
{
    public class CoreUploadFileService : CoreCatalogueService<CoreUploadFiles>, ICoreUploadFileService
    {
        public CoreUploadFileService(ICoreUploadDbContext dbContext) : base(dbContext)
        {

        }

        public void DeleteByRefId(Guid id)
        {
            var exist = Queryable.Where(e => e.RefId == id).ToList();
            if (exist.Count > 0)
            {
                foreach (var file in exist)
                {
                    coreDbContext.Set<CoreUploadFiles>().Remove(file);
                }
                coreDbContext.SaveChanges();
            }
        }
    }
}
