using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vinorsoft.Core;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Notify
{
    public class UpdateReadCommandHandler : IRequestHandler<UpdateReadCommand, int>
    {
        readonly INotificationMessageService notificationMessageService;
        public UpdateReadCommandHandler(INotificationMessageService notificationMessageService)
        {
            this.notificationMessageService = notificationMessageService;
        }

        public Task<int> Handle(UpdateReadCommand request, CancellationToken cancellationToken)
        {
            int result = 0;
            var notification = notificationMessageService.Queryable.FirstOrDefault(e => e.Id == request.NotificationMessageId);
            if (notification != null)
            {
                notification.ReadStatus = (int)CoreConstants.ReadStatus.Read;
                result = notificationMessageService.Update(notification);
                return Task.FromResult(result);
            }

            return Task.FromResult(result);
        }
    }
}
