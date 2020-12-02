using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTN.Models
{
    public class ProductDTO
    {
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Loại sản phẩm")]
        public int CategoryId { get; set; }
        [Display(Name = "Hình ảnh")]
        public IFormFile ImagePath { get; set; }
        [Display(Name = "Giá")]
        public double SellCost { get; set; }
    }
}
