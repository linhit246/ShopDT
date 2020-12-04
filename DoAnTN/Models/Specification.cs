using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DoAnTN.Models
{
    public partial class Specification
    {
        public int Id { get; set; }
        [Display(Name = "Dung lượng")]
        public string Storage { get; set; }
        public string Ram { get; set; }
        [Display(Name = "Cam chính")]
        public string Fcamera { get; set; }
        [Display(Name = "Cam phụ")]
        public string Scamera { get; set; }
        [Display(Name = "CPU")]
        public string Cpu { get; set; }
        [Display(Name = "Độ phân giải")]
        public string Resolution { get; set; }
        [Display(Name = "Pin")]
        public string Battery { get; set; }
        [Display(Name = "Hệ điều hành")]
        public string Os { get; set; }
        [Display(Name = "Màn hình")]
        public string ScreenSize { get; set; }
        [Display(Name = "SIM")]
        public string SimNumber { get; set; }
        [Display(Name = "Sạc nhanh")]
        public string FastCharge { get; set; }
        [Display(Name = "Thẻ nhớ")]
        public string Sdcard { get; set; }
        [Display(Name = "Ngày cập nhật")]
        public DateTime? LastUpdate { get; set; } = DateTime.Now;

        public virtual Product IdNavigation { get; set; }
    }
}
