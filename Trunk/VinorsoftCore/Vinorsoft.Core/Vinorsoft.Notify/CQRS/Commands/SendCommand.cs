using MediatR;
using System.Collections.Generic;

namespace Vinorsoft.Notify
{
    public class SendBaseCommand : IRequest<bool>
    {
        public string AppName { set; get; }
        public string TemplateCode { set; get; }
        public object Data { set; get; }
        public string JsonData { set; get; }
        public bool SaveLog { set; get; } = true;
        public string Recipient { set; get; }
        public bool SendToAllUser { set; get; }
    }

    public class SendEmailCommand : SendBaseCommand
    {
        public string From { set; get; }
        public string To { set; get; }
    }

    public class SendSMSCommand : SendBaseCommand
    {
        public IList<string> PhoneNumber { set; get; }
    }

    public class SendFCMCommand : SendBaseCommand
    {
        public IList<string> Token { set; get; }
    }

    public class SendExpoNotificationCommand : SendBaseCommand
    {
        public IList<string> PushToken { set; get; }
    }
}
