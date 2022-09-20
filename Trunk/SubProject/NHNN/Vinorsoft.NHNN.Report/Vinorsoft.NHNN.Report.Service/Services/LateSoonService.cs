using Vinorsoft.Core;
using Vinorsoft.NHNN.Report.Service.Entities;
using Vinorsoft.NHNN.Report.Service.Interface;

namespace Vinorsoft.NHNN.Report.Service
{
    public class LateSoonService : CoreService<AccessHistorical>, ILateSoonService
    {
        public LateSoonService(INHNNDbContext coreDbContext) : base(coreDbContext)
        {
        }
    }
}
