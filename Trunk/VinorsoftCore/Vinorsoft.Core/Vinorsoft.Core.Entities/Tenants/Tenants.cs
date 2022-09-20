using Vinorsoft.Core.Domain;

namespace Vinorsoft.Core.Entities
{
    public class Tenants : VinorsoftDomain
    {
        public string Name { get; set; }
        public string HostName { get; set; }
    }
}
