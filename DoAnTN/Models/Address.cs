using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DoAnTN.Models
{
    public partial class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Display(Name = "Họ")]
        public string FirstName { get; set; }
        [Display(Name = "Tên")]
        public string LastName { get; set; }
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
        [Display(Name = "Tỉnh/Thành phố")]
        public string City { get; set; }
        [Display(Name = "Quận/Huyện")]
        public string District { get; set; }
        [Display(Name = "Địa chỉ chi tiết")]
        public string Address1 { get; set; }
        [Display(Name = "Trạng thái")]
        public bool? Status { get; set; }
        public bool? IsDelete { get; set; } = false;
        public bool? IsDisplay { get; set; } = true;
        [Display(Name = "Ngày cập nhật")]
        public DateTime? LastUpdate { get; set; } = DateTime.Now;

        public virtual User User { get; set; }
    }
}
