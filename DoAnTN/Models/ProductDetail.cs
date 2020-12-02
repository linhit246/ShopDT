using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DoAnTN.Models
{
    public partial class ProductDetail
    {
        public ProductDetail()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        [Display(Name = "Mã sản phẩm")]
        public int ProductId { get; set; }
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }
        [Display(Name = "Màu")]
        public string ProductColor { get; set; }
        [Display(Name = "Hình ảnh")]
        public string ImagePath { get; set; }
        public bool? IsDelete { get; set; } = false;
        public bool? IsDisplay { get; set; } = true;
        [Display(Name = "Ngày cập nhật")]
        public DateTime? LastUpdate { get; set; } = DateTime.Now;

        public virtual Product Product { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
