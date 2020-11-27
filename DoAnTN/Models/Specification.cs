using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DoAnTN.Models
{
    public partial class Specification
    {
        public int Id { get; set; }
        public string Storage { get; set; }
        public string Ram { get; set; }
        public string Fcamera { get; set; }
        public string Scamera { get; set; }
        public string Cpu { get; set; }
        public string Resolution { get; set; }
        public string Battery { get; set; }
        public string Os { get; set; }
        public string ScreenSize { get; set; }
        public string SimNumber { get; set; }
        public string FastCharge { get; set; }
        public string Sdcard { get; set; }
        public DateTime? LastUpdate { get; set; } = DateTime.Now;

        public virtual Product IdNavigation { get; set; }
    }
}
