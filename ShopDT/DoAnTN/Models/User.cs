using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DoAnTN.Models
{
    public partial class User
    {
        public User()
        {
            Addresses = new HashSet<Address>();
            Comments = new HashSet<Comment>();
            ManagementSaleCodes = new HashSet<ManagementSaleCode>();
            Orders = new HashSet<Order>();
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }
        public string Password { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; } = "user.jpg";
        [Display(Name = "Họ")]
        public string FirstName { get; set; }
        [Display(Name = "Tên")]
        public string LastName { get; set; }
        [Display(Name = "Giới tính")]
        public string Gender { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Ngày sinh")]
        public DateTime? BirthDay { get; set; }
        public bool? IsDelete { get; set; } = false;
        public bool? IsDisplay { get; set; } = true;
        public DateTime? LastUpdate { get; set; } = DateTime.Now;

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ManagementSaleCode> ManagementSaleCodes { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
