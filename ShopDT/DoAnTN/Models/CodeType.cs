using System;
using System.Collections.Generic;

#nullable disable

namespace DoAnTN.Models
{
    public partial class CodeType
    {
        public CodeType()
        {
            SaleCodes = new HashSet<SaleCode>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsDelete { get; set; } = false;
        public bool? IsDisplay { get; set; } = true;
        public DateTime? LastUpdate { get; set; } = DateTime.Now;

        public virtual ICollection<SaleCode> SaleCodes { get; set; }
    }
}
