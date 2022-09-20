
using Newtonsoft.Json;

namespace Vinorsoft.Core.DTO
{
    public class NotificationMessageDTO : DomainObjectDTO
    {
        public NotificationMessageDTO()
        {
        }
        public string Subject { set; get; }
        public string Body { set; get; }
        public string AppName { set; get; }
        public int ReadStatus { set; get; }
        public int SendStatus { set; get; }
        public int NotificationType { set; get; }
        public string Recipient { set; get; }
        public string JsonData { set; get; }
        public dynamic JsonDataObject
        {
            get
            {
                try
                {
                    if (!string.IsNullOrEmpty(JsonData))
                        return JsonConvert.DeserializeObject(JsonData);
                }
                catch (System.Exception)
                {

                }
                return null;
            }
        }
    }
}
