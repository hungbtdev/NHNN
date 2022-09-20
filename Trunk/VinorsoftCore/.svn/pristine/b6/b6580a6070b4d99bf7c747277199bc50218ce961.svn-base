using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Domain.Events;
using Vinorsoft.Core.Resx;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.Entities;

namespace Vinorsoft.Core.Subcribers
{
    public abstract class BaseSubcriber<T> : INotificationHandler<CreatedEvent<T>>, INotificationHandler<UpdateEvent<T>>, INotificationHandler<DeleteEvent<T>> where T : DomainObjectDTO
    {
        protected readonly IServiceProvider serviceProvider;
        protected readonly IVEventService eventService;
        protected readonly IAuthContext authContext;
        protected readonly ILogger<BaseSubcriber<T>> logger;
        public BaseSubcriber(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            eventService = serviceProvider.GetRequiredService<IVEventService>();
            authContext = serviceProvider.GetRequiredService<IAuthContext>();
            logger = serviceProvider.GetRequiredService<ILogger<BaseSubcriber<T>>>();
        }

        public virtual Task Handle(CreatedEvent<T> @event, CancellationToken cancellationToken)
        {
            try
            {
                var result = eventService.Insert(new VEvents()
                {
                    Active = true,
                    Created = DateTime.Now,
                    CreatedBy = authContext.CurrentUser.UserName,
                    DataJson = JsonConvert.SerializeObject(@event.Data),
                    Deleted = false,
                    Id = Guid.NewGuid(),
                    Type = @event.Data.GetType().Name,
                    RefId = @event.Data.Id,
                    Description = $"{authContext.CurrentUser.UserName} {CoreMsgResource.MSG_NEWITEM_EVENT} {@event.Data.ToString()}"
                });

                return Task.FromResult(@event.Data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, new object[] { });
                throw ex;
            }
        }

        public virtual Task Handle(DeleteEvent<T> @event, CancellationToken cancellationToken)
        {
            try
            {
                var result = eventService.Insert(new VEvents()
                {
                    Active = true,
                    Created = DateTime.Now,
                    CreatedBy = authContext.CurrentUser.UserName,
                    DataJson = JsonConvert.SerializeObject(@event.Data),
                    Deleted = false,
                    Id = Guid.NewGuid(),
                    RefId = @event.Data.Id,
                    Type = @event.Data.GetType().Name,
                    Description = $"{authContext.CurrentUser.UserName} {CoreMsgResource.MSG_DELETED_EVENT} {@event.Data.ToString()}"
                });

                return Task.FromResult(@event.Data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, new object[] { });
                throw ex;
            }
        }

        public virtual Task Handle(UpdateEvent<T> @event, CancellationToken cancellationToken)
        {
            try
            {
                var result = eventService.Insert(new VEvents()
                {
                    Active = true,
                    Created = DateTime.Now,
                    CreatedBy = authContext.CurrentUser.UserName,
                    DataJson = JsonConvert.SerializeObject(@event.Data),
                    Deleted = false,
                    Id = Guid.NewGuid(),
                    RefId = @event.Data.Id,
                    Type = @event.Data.GetType().Name,
                    Description = $"{authContext.CurrentUser.UserName} {CoreMsgResource.MSG_UPDATED_EVENT}  {@event.Data.ToString()}"
                });

                return Task.FromResult(@event.Data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, new object[] { });
                throw ex;
            }
        }
    }
}
