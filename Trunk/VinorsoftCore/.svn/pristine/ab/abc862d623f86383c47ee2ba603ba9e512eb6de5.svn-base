using System;
using System.Linq;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core
{
    public class ProfileService : CoreService<Profiles>, IProfileService
    {
        public ProfileService(IProfileDbContext dbContext) : base(dbContext)
        {
        }

        public bool VerifyEmail(Guid id, string email)
        {
            return Queryable.Any(e => e.Id != id && e.Email == email);
        }

        public bool VerifyPhone(Guid id, string phone)
        {
            return Queryable.Any(e => e.Id != id && e.Phone == phone);
        }
    }
}
