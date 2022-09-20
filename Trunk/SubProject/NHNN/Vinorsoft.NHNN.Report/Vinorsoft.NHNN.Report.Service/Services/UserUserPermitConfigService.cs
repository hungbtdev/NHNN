using System;
using System.Collections.Generic;
using System.Linq;
using Vinorsoft.Core;
using Vinorsoft.NHNN.Report.Service.Entities;
using Vinorsoft.NHNN.Report.Service.Interface;

namespace Vinorsoft.NHNN.Report.Service
{
    public class UserUserPermitConfigService : CoreService<UserPermitConfigs>, IUserUserPermitConfigService
    {
        public UserUserPermitConfigService(INHNNDbContext coreDbContext) : base(coreDbContext)
        {
        }

        public IList<int> HasPermitGate(Guid userId)
        {
            IList<int> gates = new List<int>();
            var configValues = Queryable.Where(e => e.UserId == userId).ToList();
            foreach (var config in configValues)
            {
                if (!string.IsNullOrEmpty(config.DeptName))
                {
                    var splitVals = config.DeptName.Split("\n");
                    foreach (var sp in splitVals)
                    {
                        if (sp.StartsWith("Gate:"))
                        {
                            var gateSplits = sp.Replace("Gate:", "").Split(";");
                            foreach (var gate in gateSplits)
                            {
                                var valid = int.TryParse(gate, out int result);
                                if (valid)
                                {
                                    gates.Add(result);
                                }
                            }
                        }
                    }
                }
            }
            return gates;
        }

        public IList<string> HasPermitPb(Guid userId)
        {
            IList<string> pbs = new List<string>();
            var configValues = Queryable.Where(e => e.UserId == userId).ToList();
            foreach (var config in configValues)
            {
                if (!string.IsNullOrEmpty(config.DeptName))
                {
                    var splitVals = config.DeptName.Split("\n");
                    foreach (var sp in splitVals)
                    {
                       // if (sp.StartsWith("Pb:"))
                       // {
                            var pbSplits = sp.Split(";");
                            foreach (var pb in pbSplits)
                            {
                                if (!string.IsNullOrEmpty(pb))
                                {
                                    pbs.Add(pb);
                                }
                            }
                       // }
                    }
                }
            }
            return pbs;
        }
    }
}
