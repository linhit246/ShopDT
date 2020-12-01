using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnTN.Helpers;
using DoAnTN.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoAnTN.Controllers
{
    public class AdminController : Controller
    {
       
        public IActionResult Index()
        {
            if (SessionHelper.GetSession<User>(HttpContext.Session, "Login") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            else
                return View();
        }
    }
}
