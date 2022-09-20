using AutoMapper;
using KTApps.AuthService.Entities;
using KTApps.AuthService.Interface;
using KTApps.Core.Services;
using System.Linq;

namespace KTApps.AuthService
{
    public class DepartmentService : CatalogueService<Departments>, IDepartmentService
    {
        public DepartmentService(IAuthUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }


    }
}
