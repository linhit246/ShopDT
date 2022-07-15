using System;
using System.Collections.Generic;

#nullable disable

namespace DoAnTN.Models
{
    public partial class ManagementSaleCode
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SaleCodeId { get; set; }
        public bool? Status { get; set; }

        public virtual SaleCode SaleCode { get; set; }
        public virtual User User { get; set; }
    }
}
