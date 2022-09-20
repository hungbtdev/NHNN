using KTApps.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace KTApps.Core.LoggingService.Entities
{
    public class CoreApiLogItems : KTAppDomain
    {
        [MaxLength(100)]
        public string UserName { set; get; }
        public Guid? UserId { set; get; }
        public DateTime? RequestTime { set; get; }
        public long? ResponseMillis { set; get; }
        public int? StatusCode { set; get; }
        [MaxLength(100)]
        public string Method { set; get; }
        [MaxLength(1000)]
        public string Path { set; get; }
        [MaxLength(1000)]
        public string QueryString { set; get; }
        public string RequestBody { set; get; }
        public string ResponseBody { set; get; }
        [MaxLength(1000)]
        public string RefererUrl { get; set; }
    }
}
