using Expo.Server.Client;
using Expo.Server.Models;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vinorsoft.Core;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.Resx;
using Vinorsoft.Core.Utils;

namespace Vinorsoft.Notify
{
    public class SendOrderNotificationCommandHandler : IRequestHandler<SendExpoNotificationCommand, bool>
    {
        readonly IFCMTemplateService fCMTemplateService;
        readonly INotificationMessageService notificationMessageService;
        readonly IAuthContext authContext;
        readonly IUserService userService;
        readonly IDeviceTokenService deviceTokenService;

        public SendOrderNotificationCommandHandler(IServiceProvider serviceProvider)
        {
            fCMTemplateService = (IFCMTemplateService)serviceProvider.GetService(typeof(IFCMTemplateService));
            notificationMessageService = (INotificationMessageService)serviceProvider.GetService(typeof(INotificationMessageService));
            authContext = (IAuthContext)serviceProvider.GetService(typeof(IAuthContext));
            userService = (IUserService)serviceProvider.GetService(typeof(IUserService));
            deviceTokenService = (IDeviceTokenService)serviceProvider.GetService(typeof(IDeviceTokenService));
        }

        public async Task<bool> Handle(SendExpoNotificationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var template = fCMTemplateService.Queryable.FirstOrDefault(e => e.Code == request.TemplateCode && e.AppName == request.AppName);
                if (template == null)
                    throw new Exception(string.Format(CoreErrorResource.ERROR_NOT_FOUND, request.TemplateCode));
                IList<Users> users = null;
                IList<Users> Allusers = userService.Queryable.ToList();
                if (request.SendToAllUser)
                {
                    users = Allusers;
                }
                else
                {
                    users = Allusers.Where(e => e.Username.Equals(request.Recipient, StringComparison.OrdinalIgnoreCase) || e.Id.ToString() == request.Recipient).ToList();
                }

                var expoSDKClient = new PushApiClient();
                if (users != null)
                {
                    foreach (var item in users)
                    {
                        var tokenList = deviceTokenService.Queryable.Where(e => e.RefId.HasValue && e.RefId.Value == item.Id && e.Active && e.AppName == request.AppName).ToList();
                        var createBy = request.Data.GetType().GetProperty("CreatedBy").GetValue(request.Data, null);
                        var user = Allusers.FirstOrDefault(e => e.Username == $"{createBy}");

                        var message = new NotificationMessages()
                        {
                            Active = true,
                            AppName = request.AppName,
                            Body = template.Body,
                            Created = DateTime.Now,
                            CreatedBy = authContext.CurrentUser.UserName,
                            Id = Guid.NewGuid(),
                            Subject = template.Subject,
                            NotificationType = (int)CoreConstants.NotificationType.FCM,
                            ReadStatus = (int)CoreConstants.ReadStatus.UnRead,
                            Recipient = item.Username,
                            JsonData = request.JsonData
                        };
                        int badgeCount = notificationMessageService.Queryable.Count(e => e.NotificationType == (int)CoreConstants.NotificationType.FCM && e.ReadStatus == (int)CoreConstants.ReadStatus.UnRead && (e.Recipient == item.Username || e.Recipient == e.Id.ToString()));

                        foreach (var token in tokenList)
                        {
                            if (!string.IsNullOrEmpty(token.ExpoPushToken))
                            {
                                var pushTicketReq = new PushTicketRequest()
                                {
                                    PushTo = new List<string>() { token.ExpoPushToken },
                                    PushBadgeCount = badgeCount + 1,
                                    PushBody = template.Body,
                                    PushTitle = template.Subject,
                                    PushSound = "default",
                                    PushData = new
                                    {
                                        Id = request.Data.GetPropValue("Id"),
                                        NotificationId = message.Id,
                                    }
                                };
                                var result = await expoSDKClient.PushSendAsync(pushTicketReq);
                                var log = new SendLogs()
                                {
                                    Id = Guid.NewGuid(),
                                    Created = DateTime.Now,
                                    CreatedBy = authContext.CurrentUser.UserName,
                                    NotificationMessageId = message.Id,
                                    From = string.Empty,
                                    To = token.ExpoPushToken,
                                };
                                log.EndDate = DateTime.Now;
                                log.Success = true;
                                message.SendStatus = (int)CoreConstants.SendStatus.Sent;
                                if (result?.PushTicketErrors?.Count() > 0)
                                {
                                    log.Success = false;
                                    var error = string.Join(";", result.PushTicketErrors.Select(e => $"Error: {e.ErrorCode} - {e.ErrorMessage}"));
                                    log.Error = error;

                                    message.SendLogs.Add(log);
                                }
                                message.SendLogs.Add(log);
                            }
                        }

                        notificationMessageService.Insert(message);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
