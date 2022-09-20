using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Vinorsoft.Core.Domain;

namespace Vinorsoft.Core.VDbContext
{
    public static class DbContextExtension
    {
        public static void AddOrUpdateCate<T>(this DbContext context, string code, string name) where T : VinorsoftCatalogueDomain, new()
        {
            if (!context.Set<T>().Any(e => e.Code == code))
            {
                context.Add(new T()
                {
                    Id = Guid.NewGuid(),
                    Code = code,
                    Name = name,
                });
            }
        }
    }
}
