using System;
using System.Collections.Generic;

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
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }
        public double SellCost { get; set; }
        public bool? IsDelete { get; set; } = false;
        public bool? IsDisplay { get; set; } = true;
        public DateTime? LastUpdate { get; set; } = DateTime.Now;

        public virtual Category Category { get; set; }
        public virtual Specification Specification { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
