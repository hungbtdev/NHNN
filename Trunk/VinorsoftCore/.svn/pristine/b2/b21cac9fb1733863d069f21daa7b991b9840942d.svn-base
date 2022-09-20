using AutoMapper;
using KTApps.Core.Services;
using KTApps.ProfileService.Entities;
using KTApps.ProfileService.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KTApps.ProfileService
{
    public class ProfileService : DomainService<Profiles>, IProfileService
    {
        public ProfileService(ICoreProfileUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override bool Save(IList<Profiles> profiles)
        {
            foreach (var item in profiles)
            {
                var exists = unitOfWork.Repository<Profiles>().GetQueryable()
                   .AsNoTracking()
                   .Where(e => e.Id == item.Id && !e.Deleted)
                   .FirstOrDefault();

                if (exists != null)
                {
                    if (item.ProfileAddress != null && item.ProfileAddress.Count > 0)
                    {
                        foreach (var profileAddress in item.ProfileAddress)
                        {
                            if (profileAddress.Address != null)
                            {
                                unitOfWork.Repository<CatAddress>().AddOrUpdate(profileAddress.Address);
                            }
                            profileAddress.Address = null;
                            unitOfWork.Repository<ProfileAddress>().AddOrUpdate(profileAddress);
                        }
                    }

                    if (item.ProfileDegrees != null && item.ProfileDegrees.Count > 0)
                    {
                        foreach (var degrees in item.ProfileDegrees)
                        {
                            unitOfWork.Repository<ProfileDegrees>().AddOrUpdate(degrees);
                        }
                    }

                    if (item.ProfileEducationHistories != null && item.ProfileEducationHistories.Count > 0)
                    {
                        foreach (var educationHistories in item.ProfileEducationHistories)
                        {
                            unitOfWork.Repository<ProfileEducationHistories>().AddOrUpdate(educationHistories);
                        }
                    }

                    if (item.ProfileIdentications != null && item.ProfileIdentications.Count > 0)
                    {
                        foreach (var identications in item.ProfileIdentications)
                        {
                            unitOfWork.Repository<ProfileIdentications>().AddOrUpdate(identications);
                        }
                    }

                    if (item.ProfilePhones != null && item.ProfilePhones.Count > 0)
                    {
                        foreach (var phone in item.ProfilePhones)
                        {
                            unitOfWork.Repository<ProfilePhones>().AddOrUpdate(phone);
                        }
                    }

                    if (item.ProfileRelatives != null && item.ProfileRelatives.Count > 0)
                    {
                        foreach (var relative in item.ProfileRelatives)
                        {
                            unitOfWork.Repository<ProfileRelatives>().AddOrUpdate(relative);
                        }
                    }

                    if (item.ProfileWorkingHistories != null && item.ProfileWorkingHistories.Count > 0)
                    {
                        foreach (var workingHistories in item.ProfileWorkingHistories)
                        {
                            unitOfWork.Repository<ProfileWorkingHistories>().AddOrUpdate(workingHistories);
                        }
                    }

                    if (item.ProfileHealths != null)
                    {
                        unitOfWork.Repository<ProfileHealths>().AddOrUpdate(item.ProfileHealths);
                    }

                    item.ProfileAddress = null;
                    item.ProfileDegrees = null;
                    item.ProfileEducationHistories = null;
                    item.ProfileHealths = null;
                    item.ProfileIdentications = null;
                    item.ProfilePhones = null;
                    item.ProfileRelatives = null;
                    item.ProfileWorkingHistories = null;

                    exists = mapper.Map<Profiles>(item);
                    unitOfWork.Repository<Profiles>().Update(exists);
                }
                else
                {
                    unitOfWork.Repository<Profiles>().Create(item);
                }
            }

            unitOfWork.Save();
            return true;
        }

        public bool SaveDegrees(IList<ProfileDegrees> profileDegrees)
        {
            foreach (var degree in profileDegrees)
            {
                var studentValid = unitOfWork.Repository<Profiles>().GetQueryable()
                    .AsNoTracking()
                    .Any(e => e.Id == degree.ProfileId);
                if (!studentValid)
                {
                    throw new Exception(string.Format("Profile id {0} not exists", degree.ProfileId));
                }
                unitOfWork.Repository<ProfileDegrees>().AddOrUpdate(degree);
            }
            unitOfWork.Save();
            return true;
        }
    }
}
