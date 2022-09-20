using System;
using System.ComponentModel.DataAnnotations;

namespace Vinorsoft.Core.Domain.Queries
{
    public class VQuery<T> : QueryBase<T> where T: class
    {
        public VQuery()
        {
        }

        public VQuery(Guid key)
        {
            Key = key;
        }

        [Required]
        public Guid Key { get; set; }
    }
}
