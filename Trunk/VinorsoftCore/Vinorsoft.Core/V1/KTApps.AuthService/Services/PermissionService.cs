using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using KTApps.AuthService.Entities;
using KTApps.AuthService.Interface;

namespace KTApps.AuthService
{
    public class PermissionService : AuthCatalogueService<Permissions>, IPermissionService
    {
        public PermissionService(IAuthUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
