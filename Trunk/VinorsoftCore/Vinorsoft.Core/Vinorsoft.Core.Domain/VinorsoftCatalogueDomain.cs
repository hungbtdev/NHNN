using System.ComponentModel.DataAnnotations;

namespace Vinorsoft.Core.Domain
{
    public abstract class VinorsoftCatalogueDomain : VinorsoftDomain
    {
        /// <summary>
        /// Mã không trùng
        /// </summary>
        [MaxLength(255)]
        [Required]
        public virtual string Code { get; set; }

        /// <summary>
        /// Tên 
        /// </summary>
        [MaxLength(4000)]
        [Required]
        public virtual string Name { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        [MaxLength(4000)]
        public virtual string Description { get; set; }
    }
}
