using System;
using System.Collections.Generic;

#nullable disable

namespace DoAnTN.Models
{
    public partial class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Role1 { get; set; }
        public bool? IsDelete { get; set; } = false;
        public bool? IsDisplay { get; set; } = true;
        public DateTime? LastUpdate { get; set; } = DateTime.Now;

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
