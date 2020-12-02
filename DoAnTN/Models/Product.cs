using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DoAnTN.Models
{
    public partial class Product
    {
        public Product()
        {
            Comments = new HashSet<Comment>();
            ProductDetails = new HashSet<ProductDetail>();
        }

        public int Id { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Loại sản phẩm")]
        public int CategoryId { get; set; }
        [Display(Name = "Hình ảnh")]
        public string ImagePath { get; set; }
        [Display(Name = "Giá")]
        public double SellCost { get; set; }
        public bool? IsDelete { get; set; } = false;
        public bool? IsDisplay { get; set; } = true;
        [Display(Name = "Ngày cập nhật")]
        public DateTime? LastUpdate { get; set; } = DateTime.Now;

        public virtual Category Category { get; set; }
        public virtual Specification Specification { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
