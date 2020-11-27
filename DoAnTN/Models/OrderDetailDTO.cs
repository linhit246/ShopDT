using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTN.Models
{
    public class OrderDetailDTO
    {
        public int ProductDetailID { get; set; }
        public string ProductName { get; set; }
        public string ProductColor { get; set; }
        public string ImagePath { get; set; }
        public double SellCost { get; set; }
        public int Quantity { get; set; }
    }
}
