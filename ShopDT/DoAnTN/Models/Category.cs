using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DoAnTN.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        public bool? IsDelete { get; set; } = false;
        public bool? IsDisplay { get; set; } = true;
        [Display(Name = "Ngày cập nhật")]
        public DateTime? LastUpdate { get; set; } = DateTime.Now;

        public virtual ICollection<Product> Products { get; set; }
    }
}
