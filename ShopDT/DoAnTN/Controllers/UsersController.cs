using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnTN.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using DoAnTN.Helpers;
using System.Linq.Dynamic.Core;

namespace DoAnTN.Controllers
{
    public class UsersController : Controller
    {
        private readonly ShopDienThoaiContext _context;

        public UsersController(ShopDienThoaiContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            if (SessionHelper.GetSession<User>(HttpContext.Session, "Login") == null)
            {
                return RedirectToAction("Login");
            }
            return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var product = from order in _context.Orders
            //              join orderDetail in _context.OrderDetails on order.Id equals orderDetail.OrderId
            //              join productDetail in _context.ProductDetails on orderDetail.ProductDetailId equals productDetail.Id
            //              where order.UserId == id
            //              group new {order, orderDetail, productDetail} by new {order.Id} into z
            //              select new { Id = z.Select(x => x.order.Id),ImagePath = z.Select(x => x.productDetail.ImagePath) };
            var product = _context.Orders.Include(x => x.OrderDetails).ThenInclude(y => y.ProductDetail).Where(z => z.UserId == id).OrderByDescending(x => x.OrderDate);
            List<OrderDTO> orders = new List<OrderDTO>();
            foreach (var item in product)
            {
                OrderDTO od = new OrderDTO();
                od.Id = item.Id;
                od.ImagePath = item.OrderDetails.FirstOrDefault().ProductDetail.ImagePath;
                od.OrderDate = item.OrderDate;
                od.Total = item.Total;
                orders.Add(od);
            }
            ViewBag.product = orders;
            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            var address = _context.Addresses.Where(x => x.UserId == id).FirstOrDefault();
            ViewBag.Address = address;
            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                if (IsExits(userDTO))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại!");
                }
                else
                {
                    User u = new User();
                    u.Username = userDTO.Username;
                    u.Password = ComputeSHA256Hash(userDTO.Password);
                    u.Avatar = UploadedFile(userDTO.Avatar);
                    u.FirstName = userDTO.FirstName;
                    u.LastName = userDTO.LastName;
                    u.Gender = userDTO.Gender;
                    u.BirthDay = userDTO.BirthDay;
                    _context.Add(u);
                    await _context.SaveChangesAsync();
                    var x = _context.Users.Where(x => x.Username == userDTO.Username).FirstOrDefault();
                    UserRole r = new UserRole();
                    r.UserId = x.Id;
                    r.RoleId = 3;
                    _context.Add(r);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(userDTO);
        }

        [NonAction]
        private string UploadedFile(IFormFile file)
        {
            string newFileName = null;

            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                var fileExtension = Path.GetExtension(fileName);
                newFileName = String.Concat(myUniqueFileName, fileExtension);
                var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", "user")).Root + $@"\{newFileName}";
                using (FileStream fs = System.IO.File.Create(filepath))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
            return newFileName;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                if (CheckLogin(login) == 1)
                {
                    var user = _context.Users.Where(x => x.Username == login.UserName).FirstOrDefault();
                    SessionHelper.SetSession(HttpContext.Session, "Login", user);
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
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("IndexClient", "Products");
                    }
                }
                else if (CheckLogin(login) == -1)
                {
                    ModelState.AddModelError("", "Mật khẩu không chính xác.");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản này chưa đăng kí, vui lòng đăng kí để sử dụng dịch vụ này.");
                }
            }
            return View();
        }

        public IActionResult LogOut()
        {
            SessionHelper.SetSession(HttpContext.Session, "Login", null);
            return RedirectToAction("IndexClient", "Products");
        }

        private int CheckLogin(Login login)
        {
            foreach (var item in _context.Users)
            {
                if (item.Username.Trim() == login.UserName.Trim())
                {
                    if (ComputeSHA256Hash(login.PassWord) == item.Password)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }

        private bool IsExits(UserDTO userDTO)
        {
            foreach (var item in _context.Users)
            {
                if (item.Username.Trim() == userDTO.Username.Trim())
                {
                    return true;
                }
            }
            return false;
        }

        public string ComputeSHA256Hash(string password)
        {
            using (SHA256 hash = SHA256.Create())
            {
                byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte item in bytes)
                {
                    builder.Append(item.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password,Avatar,FirstName,LastName,Gender,BirthDay,IsDelete,IsDisplay,LastUpdate")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
