using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnTN.Helpers;
using DoAnTN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnTN.Controllers
{
    public class AdminController : Controller
    {
        private readonly ShopDienThoaiContext _context;

        public AdminController(ShopDienThoaiContext context)
        {
            _context = context;
        }
        [Route("/Admin")]       
        public async Task<IActionResult> Index()
        {
            if (SessionHelper.GetSession<User>(HttpContext.Session, "Login") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            else
            {
                var user = SessionHelper.GetSession<User>(HttpContext.Session, "Login");
                var role = _context.UserRoles.Where(x => x.UserId == user.Id).Include(p => p.Role);
                bool check = false;
                foreach (var item in role)
                {
                    if (item.Role.Role1 == 1 || item.Role.Role1 == 2)
                    {
                        check = true;
                    }
                }
                if (check)
                {
                    var context = _context.Users.Where(x => x.Id == user.Id).Include(p => p.UserRoles);
                    ViewBag.Roles = role;
                    return View(await context.ToListAsync());
                }
                else
                {
                    return RedirectToAction("IndexClient", "Products");
                }
            }
        }
    }
}
