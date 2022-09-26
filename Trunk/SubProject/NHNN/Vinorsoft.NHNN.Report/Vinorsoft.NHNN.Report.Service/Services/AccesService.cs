using Vinorsoft.Core;
using Vinorsoft.NHNN.Report.Service.Entities;
using Vinorsoft.NHNN.Report.Service.Interface;

namespace Vinorsoft.NHNN.Report.Service
{
    public class AccesService : CoreService<Acces>, IAccesService
    {
        public AccesService(IAlizeDbContext coreDbContext) : base(coreDbContext)
        {
        }
    }
}
