using MediatR;
using System;

namespace Vinorsoft.Core.Notification.Commands
{
    public class DeleteDeviceTokenCommands : IRequest<bool>
    {
        public string Token { set; get; }

        public Guid? UserId { set; get; }

        public DeleteDeviceTokenCommands(string token, Guid? userId)
        {
            Token = token;
            UserId = userId;
        }
    }
    
}
