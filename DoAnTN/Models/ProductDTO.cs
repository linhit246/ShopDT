using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTN.Models
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public IFormFile ImagePath { get; set; }
        public double SellCost { get; set; }
    }
}
