using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.Domain;
using Vinorsoft.Core.Domain.Queries;

namespace Vinorsoft.Core.Query
{

    public abstract class CoreVQueryHandler<T, E, TService> : IRequestHandler<VQuery<T>, T>, IRequestHandler<VQueryable<IQueryable<T>>, IQueryable<T>> 
        where T: DomainObjectDTO where E: VinorsoftDomain where TService : ICoreService<E>
    {
        protected readonly TService service;
        protected readonly IMapper mapper;
        protected readonly ILogger<T> logger;

        public CoreVQueryHandler(IServiceProvider serviceProvider)
        {
            this.service = serviceProvider.GetRequiredService<TService>();
            this.mapper = serviceProvider.GetRequiredService<IMapper>(); ;
            this.logger = serviceProvider.GetRequiredService<ILogger<T>>(); ;
        }

        public virtual async Task<T> Handle(VQuery<T> request, CancellationToken cancellationToken)
        {
            var result = await service.GetByIdAsync(request.Key);
            if (result != null)
            {
                return mapper.Map<T>(result);
            }
            return null;
        }

        public virtual Task<IQueryable<T>> Handle(VQueryable<IQueryable<T>> request, CancellationToken cancellationToken)
        {
            var result = service.Queryable.ProjectTo<T>(mapper.ConfigurationProvider);
            return Task.FromResult(result);
        }
        
    }
}
