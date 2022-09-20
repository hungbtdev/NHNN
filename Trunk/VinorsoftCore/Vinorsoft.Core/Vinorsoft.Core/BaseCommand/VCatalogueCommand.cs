using System;
using System.Threading;
using System.Threading.Tasks;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.Domain;
using Vinorsoft.Core.Domain.Comands;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.Command
{
    public abstract class VCatalogueCommand<T,E, TService> : VBaseCommand<T, E, TService>  where T : CatalogueObjectDTO where E: VinorsoftCatalogueDomain where TService : ICoreCatalogueService<E>
    {
        public VCatalogueCommand(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public override async Task<T> Handle(CreateComand<T> request, CancellationToken cancellationToken)
        {

            if (service.Any(e => e.Code == request.Data.Code && e.Id != request.Data.Id))
            {
                throw new ArgumentException(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, request.Data.Code));
            }
            return await base.Handle(request, cancellationToken);
        }

        public override async Task<T> Handle(UpdateComand<T> request, CancellationToken cancellationToken)
        {
            if (service.Any(e => e.Code == request.Data.Code && e.Id != request.Data.Id))
            {
                throw new ArgumentException(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, request.Data.Code));
            }
            return await base.Handle(request, cancellationToken);
        }
    }
}
