using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTN.Models
{
    public class ProductDetailDTO
    {
        [Display(Name = "Mã sản phẩm")]
        public int ProductId { get; set; }
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }
        [Display(Name = "Màu")]
        public string ProductColor { get; set; }
        [Display(Name = "Hình ảnh")]
        public IFormFile ImagePath { get; set; }
    }
}
