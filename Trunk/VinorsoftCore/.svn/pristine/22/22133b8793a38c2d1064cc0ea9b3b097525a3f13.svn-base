using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vinorsoft.Core.Domain;
using Vinorsoft.Core.Domain.Comands;
using Vinorsoft.Core.Domain.Events;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.Command
{
    public partial class VBaseCommand<T, E, TService> : IRequestHandler<CreateComand<T>, T>, IRequestHandler<UpdateComand<T>, T>, IRequestHandler<DeleteComand<T>, T> where T : DomainObjectDTO where E : VinorsoftDomain where TService : ICoreService<E>
    {
        protected readonly TService service;
        protected readonly IMapper mapper;
        protected readonly IMediator mediator;
        protected readonly IAuthContext authContext;

        public VBaseCommand(IServiceProvider serviceProvider)
        {
            this.service = serviceProvider.GetRequiredService<TService>();
            this.mapper = serviceProvider.GetRequiredService<IMapper>(); 
            this.mediator = serviceProvider.GetRequiredService<IMediator>(); 
            this.authContext = serviceProvider.GetRequiredService<IAuthContext>(); 
        }

        protected M SetAudit<M>(M model, bool isNew) where M : VinorsoftDomain
        {
            if (isNew)
            {
                model.CreatedBy = authContext.CurrentUser?.UserName;
                model.Created = DateTime.Now;
                model.Updated = DateTime.Now;
                model.UpdatedBy = authContext.CurrentUser?.UserName;
            }
            else
            {
                model.Updated = DateTime.Now;
                model.UpdatedBy = authContext.CurrentUser?.UserName;
            }

            return model;
        }

        public virtual async Task<T> Handle(CreateComand<T> request, CancellationToken cancellationToken)
        {
            if (service.Any(request.Data.Id))
            {
                throw new ArgumentException(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, request.Data.Id), nameof(request.Data.Id));
            }

            var newItem = mapper.Map<E>(request.Data);
            newItem = SetAudit(newItem, true);

            int result = service.Insert(newItem);

            if (result <= 0)
            {
                throw new ApplicationException();
            }
            await mediator.Publish(new CreatedEvent<T>(request.Data), cancellationToken);
            return mapper.Map<T>(newItem);
        }

        public virtual async Task<T> Handle(UpdateComand<T> request, CancellationToken cancellationToken)
        {
            if (!service.Any(request.Data.Id))
            {
                throw new ArgumentException(string.Format(CoreErrorResource.ERROR_NOT_FOUND, request.Data.Id), nameof(request.Data.Id));
            }

            var update = mapper.Map<E>(request.Data);
            update = SetAudit(update, false);
            int result = service.Update(update);

            if (result <= 0)
            {
                throw new ApplicationException();
            }
            await mediator.Publish(new UpdateEvent<T>(request.Data), cancellationToken);
            return mapper.Map<T>(update);
        }

        public virtual async Task<T> Handle(DeleteComand<T> request, CancellationToken cancellationToken)
        {
            if (!service.Any(request.Data.Id))
            {
                throw new ArgumentException(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, request.Data.Id), nameof(request.Data.Id));
            }

            var deleteItem = mapper.Map<E>(request.Data);
            deleteItem = SetAudit(deleteItem, false);
            int result = service.Delete(deleteItem.Id);

            if (result <= 0)
            {
                throw new Exception(CoreErrorResource.ERROR_UNKNOWN);
            }
            await mediator.Publish(new DeleteEvent<T>(request.Data), cancellationToken);
            return mapper.Map<T>(deleteItem);
        }
    }
}
