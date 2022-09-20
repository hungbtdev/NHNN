using KTApps.Core.NotificationService.Interface;
using KTApps.Core.NotificationService.Notify.Entities;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace KTApps.Core.NotificationService.Notify.Jobs
{
    public class CoreFCMNotifiy : ICoreFCMNotifiy
    {
        public string FCMResult { set; get; }

        protected readonly FCMConfiguration configuration;

        public CoreFCMNotifiy(FCMConfiguration configaration)
        {
            this.configuration = configaration;
        }

        public void Notify(FCMNotificationMessage message)
        {
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            tRequest.Headers.Add(string.Format("Authorization: key={0}", configuration.APIKey));
            tRequest.Headers.Add(string.Format("Sender: id={0}", configuration.SenderId));
            tRequest.ContentType = "application/json";
            string postbody = message.JsonData;
            byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
            tRequest.ContentLength = byteArray.Length;
            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        if (dataStreamResponse != null)
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                FCMResult = tReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }
    }
}
