using AutoMapper;
using KTApps.AuthService.Entities;
using KTApps.AuthService.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace KTApps.AuthService
{
    public class PermitObjectService : AuthCatalogueService<PermitObjects>, IPermitObjectService
    {
        public PermitObjectService(IAuthUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override bool Save(PermitObjects item)
        {
            var existCode = unitOfWork.Repository<PermitObjects>().GetQueryable()
                 .AsNoTracking()
                 .Where(e => e.Code == item.Code && !e.Deleted)
                 .FirstOrDefault();

            if (existCode != null && item.Id != existCode.Id)
            {
                throw new Exception("Mã đã tồn tại");
            }

            var exists = unitOfWork.Repository<PermitObjects>().GetQueryable()
                .AsNoTracking()
                .Where(e => e.Id == item.Id && !e.Deleted)
                .FirstOrDefault();

            if (exists != null)
            {
                if (item.PermitObjectSidebars.Count > 0)
                {
                    foreach (var sidebar in item.PermitObjectSidebars)
                    {
                        unitOfWork.Repository<PermitObjectSidebars>().AddOrUpdate(sidebar);
                    }
                }

                item.PermitObjectSidebars = null;

                exists = mapper.Map<PermitObjects>(item);
                unitOfWork.Repository<PermitObjects>().Update(exists);
                unitOfWork.Save();
                return true;
            }
            else
            {
                unitOfWork.Repository<PermitObjects>().Create(item);
                unitOfWork.Save();
                return true;
            }
        }
    }
}
