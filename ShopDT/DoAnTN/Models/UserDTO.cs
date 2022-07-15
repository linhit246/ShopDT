using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTN.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public IFormFile Avatar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool? IsDelete { get; set; } = false;
        public bool? IsDisplay { get; set; } = true;
        public DateTime? LastUpdate { get; set; } = DateTime.Now;
    }
}
