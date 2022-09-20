using System;

namespace Vinorsoft.Core.DTO
{
    public sealed class CachingLoginDTO
    {
        public Guid UserId { set; get; }
        public string UserName { set; get; }
        public string FullName { set; get; }
    }
}
