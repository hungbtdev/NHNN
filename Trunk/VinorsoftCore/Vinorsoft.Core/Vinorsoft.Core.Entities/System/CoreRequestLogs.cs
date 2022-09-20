using Vinorsoft.Core.Domain;

namespace Vinorsoft.Core.Entities
{
    public class CoreRequestLogs : VinorsoftDomain
    {
        public string Host { set; get; }
        public string Body { set; get; }
        public string Method { set; get; }
        public string Path { set; get; }
        public string StatusCode { set; get; }
        public string Controller { set; get; }
        public string Action { set; get; }
        public string Area { set; get; }
        public string UserName { set; get; }
        public string FullName { set; get; }
        public bool IsAjaxRequest { set; get; }
    }
}
