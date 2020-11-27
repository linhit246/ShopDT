using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTN.Models
{
    public class Login
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool rememberMe { get; set; } = false;
    }
}
