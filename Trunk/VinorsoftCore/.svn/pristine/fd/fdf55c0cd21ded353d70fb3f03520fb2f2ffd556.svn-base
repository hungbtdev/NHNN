using System;
using System.Linq;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Entities;

namespace Vinorsoft.Core.Interface
{
    public interface IPermitObjectService : ICoreCatalogueService<PermitObjects>
    {
        IQueryable<PermitObjectTreeNodeDTO> BuildTreeNode(Guid userGroupId);
    }
}
