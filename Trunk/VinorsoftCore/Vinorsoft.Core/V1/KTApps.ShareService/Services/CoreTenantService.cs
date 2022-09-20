using AutoMapper;
using KTApps.Core.EF;
using KTApps.Core.Services;
using KTApps.ShareService.Entities;
using KTApps.ShareService.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace KTApps.ShareService
{
    public class CoreTenantService : CatalogueService<CoreTenants>, ICoreTenantService
    {
        public CoreTenantService(ICoreConfigUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }


        public override CoreTenants GetById(Guid id)
        {
            return base.GetById(id, e => new CoreTenants()
            {
                Active = e.Active,
                Code = e.Code,
                Created = e.Created,
                CreatedBy = e.CreatedBy,
                Deleted = e.Deleted,
                Id = e.Id,
                Description = e.Description,
                Name = e.Name,
                RefId = e.RefId,
                CoreTenantConnections = e.CoreTenantConnections
            });
        }

        public override bool Save(CoreTenants item)
        {
            var existCode = unitOfWork.Repository<CoreTenants>().GetQueryable()
                .AsNoTracking()
                .Where(e =>
                e.Code == item.Code
                && !e.Deleted)
                .FirstOrDefault();

            if (existCode != null && item.Id != existCode.Id)
            {
                throw new Exception("Mã đã tồn tại");
            }

            var exists = unitOfWork.Repository<CoreTenants>().GetQueryable()
                .AsNoTracking()
                .Where(e =>
                e.Id == item.Id
                && !e.Deleted)
                .FirstOrDefault();
            if (exists != null)
            {
                if (item.CoreTenantConnections.Count > 0)
                {
                    foreach (var connection in item.CoreTenantConnections)
                    {
                        var existConnection = unitOfWork.Repository<CoreTenantConnections>()
                            .GetQueryable()
                            .AsNoTracking()
                            .Where(e =>
                            e.Id == connection.Id && !e.Deleted)
                            .FirstOrDefault();
                        if (existConnection != null)
                        {
                            if (item.Deleted)
                            {
                                unitOfWork.Repository<CoreTenantConnections>().Delete(existConnection);
                            }
                            else
                            {
                                existConnection = mapper.Map<CoreTenantConnections>(connection);
                                unitOfWork.Repository<CoreTenantConnections>().Update(existConnection);
                            }
                        }
                        else
                        {
                            unitOfWork.Repository<CoreTenantConnections>().Create(connection);
                        }
                    }
                }
                exists = mapper.Map<CoreTenants>(item);
                unitOfWork.Repository<CoreTenants>().Update(exists);
                unitOfWork.Save();
                return true;
            }
            else
            {
                unitOfWork.Repository<CoreTenants>().Create(item);
                unitOfWork.Save();
                return true;
            }
        }
    }
}
