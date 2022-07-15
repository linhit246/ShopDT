using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnTN.Models;
using DoAnTN.Helpers;

namespace DoAnTN.Controllers
{
    public class AddressesController : Controller
    {
        private readonly ShopDienThoaiContext _context;

        public AddressesController(ShopDienThoaiContext context)
        {
            _context = context;
        }

        // GET: Addresses
        public async Task<IActionResult> Index()
        {
            var shopDienThoaiContext = _context.Addresses.Include(a => a.User);
            return View(await shopDienThoaiContext.ToListAsync());
        }

        public async Task<IActionResult> IndexClient(int id)
        {
            var shopDienThoaiContext = _context.Addresses.Where(a => a.UserId == id).OrderByDescending(x => x.LastUpdate);
            ViewBag.UserID = shopDienThoaiContext.FirstOrDefault();
            return View(await shopDienThoaiContext.ToListAsync());
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Addresses/Create
        public IActionResult Create(int id)
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Database.OpenConnection();
                _context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT Address ON;");
                var userId = SessionHelper.GetSession<User>(HttpContext.Session, "Login");
                address.UserId = userId.Id;
                _context.Add(address);
                await _context.SaveChangesAsync();
                _context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT Address OFF");
                _context.Database.CloseConnection();
                return RedirectToAction("Details", "Users", new {@id = userId.Id });
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName", address.UserId);
            return View(address);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = _context.Addresses.Where(x => x.UserId == id).FirstOrDefault();
            if (address == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "LastName", address.UserId);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,FirstName,LastName,Phone,City,District,Address1,Status,IsDelete,IsDisplay,LastUpdate")] Address address)
        {
            if (id != address.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName", address.UserId);
            return View(address);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var address = await _context.Addresses
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Accept(int id)
        {
            var user = SessionHelper.GetSession<User>(HttpContext.Session, "Login");
            var order = await _context.Addresses.FindAsync(id);
            order.LastUpdate = DateTime.Now;
            _context.Addresses.Update(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("IndexClient", "Addresses", new {@id = user.Id });
        }
        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(e => e.Id == id);
        }
    }
}
