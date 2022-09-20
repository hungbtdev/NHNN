using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core
{
    public class DatabaseTenantProvider : ITenantProvider
    {
        private Guid? _tenantId;
        readonly ITenantsDbContext context;
        readonly IHttpContextAccessor accessor;

        public DatabaseTenantProvider(ITenantsDbContext context, IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
            this.context = context;
           
        }

        public Guid? GetTenantId()
        {
            if (!_tenantId.HasValue)
            {
                if (accessor != null && accessor.HttpContext != null)
                {
                    var host = accessor.HttpContext.Request.Host.Value;
                    _tenantId = context.Set<Tenants>().FirstOrDefault(t => t.HostName == host)?.Id;
                }
            }
            return _tenantId;
        }
    }
}
