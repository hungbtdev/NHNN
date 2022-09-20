using KTApps.AuthService.Entities;
using KTApps.Core.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTApps.AuthService.Interface
{
    public interface IPermissionRepository : ICatalogueRepository<Permissions>
    {
    }
}
