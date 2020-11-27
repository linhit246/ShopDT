using System;
using System.Collections.Generic;

#nullable disable

namespace DoAnTN.Models
{
    public partial class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address1 { get; set; }
        public bool? Status { get; set; }
        public bool? IsDelete { get; set; } = false;
        public bool? IsDisplay { get; set; } = true;
        public DateTime? LastUpdate { get; set; } = DateTime.Now;

        public virtual User User { get; set; }
    }
}
