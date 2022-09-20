using System;
using System.Collections.Generic;
using System.Text;

namespace Vinorsoft.Core.DTO
{
    public class PermitObjectTreeNodeDTO
    {
        public Guid Id { set; get; }
        public string Name { set; get; }
        public TreeNodeType Type { set; get; }
        public bool Expanded { get; set; }
        public bool Checked { set; get; }
        public IEnumerable<PermitObjectTreeNodeDTO> Items { get; set; }
    }

    public enum TreeNodeType
    {
         PermitObject = 1,
         Permission = 2
    }
}
