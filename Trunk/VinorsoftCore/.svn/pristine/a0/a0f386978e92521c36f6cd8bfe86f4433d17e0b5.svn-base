using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vinorsoft.Core.Domain
{
    public abstract class VinorsoftDomain
    {
        public VinorsoftDomain()
        {
            Created = DateTime.Now;
        }

        /// <summary>
        /// Khóa chính, không trùng
        /// </summary>
        [Key]
        [Required]
        public virtual Guid Id { set; get; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        [Required]
        public virtual DateTime Created { set; get; }

        /// <summary>
        /// Ngày cập nhật
        /// </summary>
        public virtual DateTime? Updated { set; get; }

        /// <summary>
        /// Dánh dấu xóa hay chưa
        /// </summary>
        [DefaultValue(false)]
        public virtual bool Deleted { get; set; }

        /// <summary>
        /// Tên đăng nhập người tạo
        /// </summary>
        [MaxLength(255)]
        public virtual string CreatedBy { get; set; }

        /// <summary>
        /// Tên đăng nhập người cập nhật
        /// </summary>
        [MaxLength(255)]
        public virtual string UpdatedBy { get; set; }

        /// <summary>
        /// Kích hoạt
        /// </summary>
        [DefaultValue(true)]
        public virtual bool Active { set; get; }

        public virtual Guid? TenantId { set; get; }

    }
}
