using MediatR;
using System;

namespace Vinorsoft.Notify
{
    public class UpdateReadCommand : IRequest<int>
    {
        public UpdateReadCommand(Guid notificationMessageId)
        {
            NotificationMessageId = notificationMessageId;
        }

        public Guid NotificationMessageId { set; get; }
    }
}
