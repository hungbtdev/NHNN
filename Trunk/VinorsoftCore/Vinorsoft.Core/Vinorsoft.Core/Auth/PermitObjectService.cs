using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

using Vinorsoft.Core.DTO;

namespace Vinorsoft.Core
{
    public class PermitObjectService : CoreCatalogueService<PermitObjects>, IPermitObjectService
    {
        public PermitObjectService(IAuthDbContext coreDbContext) : base(coreDbContext)
        {
        }

        public IQueryable<PermitObjectTreeNodeDTO> BuildTreeNode(Guid userGroupId)
        {
            var hasPermitItems = coreDbContext.Set<PermitObjectPermissions>().Where(e => !e.Deleted && e.GroupId == userGroupId)
               .AsNoTracking().ToList();
            return coreDbContext.Set<PermitObjects>().AsNoTracking().Where(s => !s.Deleted).Select(e => new PermitObjectTreeNodeDTO()
            {
                Id = e.Id,
                Name = e.Name,
                Type = TreeNodeType.PermitObject,
                Items = coreDbContext.Set<Permissions>().AsNoTracking().Where(s=> !s.Deleted).Select(s => new PermitObjectTreeNodeDTO()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Type = TreeNodeType.Permission,
                    Checked = hasPermitItems.Any(x => x.PermissionId == s.Id && e.Id == x.PermitObjectId)
                })
            });
        }

        public override int Update(PermitObjects entity)
        {
            var exists = coreDbContext.Set<PermitObjectSidebars>().Where(e => e.PermitObjectId == entity.Id);
            if (exists.Any())
            {
                foreach (var item in exists)
                {
                    coreDbContext.Set<PermitObjectSidebars>().Remove(item);
                }
            }
            if (entity.PermitObjectSidebars.Any())
            {
                coreDbContext.Set<PermitObjectSidebars>().AddRange(entity.PermitObjectSidebars);
            }
            return base.Update(entity);
        }
    }
}
