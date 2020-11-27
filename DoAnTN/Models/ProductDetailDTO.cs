using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTN.Models
{
    public class ProductDetailDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ProductColor { get; set; }
        public IFormFile ImagePath { get; set; }
    }
}
