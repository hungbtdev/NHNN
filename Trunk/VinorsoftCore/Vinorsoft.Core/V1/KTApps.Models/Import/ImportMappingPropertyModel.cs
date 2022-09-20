using KTApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KTApps.Models
{

    public class ColumnModel : KTAppDomainCatalogueModel
    {
    }

    public class Catalogue : KTAppDomainCatalogueModel
    {
    }
    public class ImportMappingPropertyModel
    {
        public ImportMappingPropertyModel()
        {

        }

        /// <summary>
        /// Property của object cần import
        /// </summary>
        public string PropertyName { get; set; }
        public string PropertyDescription { get; set; }

        /// <summary>
        /// Cột trong file import tương ứng
        /// </summary>
        public string MappingWithColumn { set; get; }

        /// <summary>
        /// Tự động tạo thông tin theo cột
        /// </summary>
        public string AutoGenerateColumn { set; get; }

        /// <summary>
        /// Tự động tạo thông tin 
        /// </summary>
        public bool AutoGenerateIfNull { set; get; }
        /// <summary>
        /// Bắt buộc nhập trong file
        /// </summary>
        public bool Required { set; get; }

        /// <summary>
        /// Tên danh mục tạo mới nếu không tồn tại
        /// </summary>
        public string Catalogue { set; get; }

        /// <summary>
        /// Danh sách cột trong file excel
        /// Đang fix 1 số cột không phải lấy từ file import
        /// </summary>
        public IList<ColumnModel> Columns
        {
            get
            {
                return "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().Select(e => new ColumnModel()
                {
                    Id = Guid.NewGuid(),
                    Active = true,
                    Code = e.ToString(),
                    Name = e.ToString()
                }).ToList();
            }
        }

        public IList<Catalogue> Catalogues
        {
            get
            {
                return new List<Catalogue>()
                {
                    new Catalogue()
                    {
                        Code = "Country",
                        Name = "Quốc gia"
                    },
                    new Catalogue()
                    {
                        Code = "Department",
                        Name = "Phòng ban"
                    }
                };
            }
           
        }

    }
}
