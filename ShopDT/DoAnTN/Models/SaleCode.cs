using System;
using System.Collections.Generic;

#nullable disable

namespace DoAnTN.Models
{
    public partial class SaleCode
    {
        public SaleCode()
        {
            ManagementSaleCodes = new HashSet<ManagementSaleCode>();
        }

        public int Id { get; set; }
        public int CodeTypeId { get; set; }
        public string Code { get; set; }
        public string ConditionSale { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public double Sale { get; set; }
        public bool? IsDelete { get; set; } = false;
        public bool? IsDisplay { get; set; } = true;
        public DateTime? LastUpdate { get; set; } = DateTime.Now;

        public virtual CodeType CodeType { get; set; }
        public virtual ICollection<ManagementSaleCode> ManagementSaleCodes { get; set; }
    }
}
