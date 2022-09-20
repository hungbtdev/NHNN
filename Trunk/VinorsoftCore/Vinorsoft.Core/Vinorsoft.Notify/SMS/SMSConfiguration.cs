using Vinorsoft.Notify.Interface;

namespace Vinorsoft.Notify
{
    public class SMSConfiguration : ISMSConfiguration
    {
        public string ApiKey { set; get; }

        public string SecretKey { set; get; }

        public string Brandname { set; get; }

        public string ApiUrl { set; get; }
    }
}
