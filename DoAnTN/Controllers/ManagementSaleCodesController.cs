using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnTN.Models;

namespace DoAnTN.Controllers
{
    public class ManagementSaleCodesController : Controller
    {
        private readonly ShopDienThoaiContext _context;

        public ManagementSaleCodesController(ShopDienThoaiContext context)
        {
            _context = context;
        }

        // GET: ManagementSaleCodes
        public async Task<IActionResult> Index(int? id)
        {
            var shopDienThoaiContext = _context.ManagementSaleCodes.Include(m => m.SaleCode).Include(m => m.User).Where(m => m.UserId == id);
            return View(await shopDienThoaiContext.ToListAsync());
        }

        // GET: ManagementSaleCodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var managementSaleCode = await _context.ManagementSaleCodes
                .Include(m => m.SaleCode)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (managementSaleCode == null)
            {
                return NotFound();
            }

            return View(managementSaleCode);
        }

        // GET: ManagementSaleCodes/Create
        public IActionResult Create()
        {
            ViewData["SaleCodeId"] = new SelectList(_context.SaleCodes, "Id", "Code");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName");
            return View();
        }

        // POST: ManagementSaleCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,SaleCodeId,Status")] ManagementSaleCode managementSaleCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(managementSaleCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SaleCodeId"] = new SelectList(_context.SaleCodes, "Id", "Code", managementSaleCode.SaleCodeId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName", managementSaleCode.UserId);
            return View(managementSaleCode);
        }

        // GET: ManagementSaleCodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var managementSaleCode = await _context.ManagementSaleCodes.FindAsync(id);
            if (managementSaleCode == null)
            {
                return NotFound();
            }
            ViewData["SaleCodeId"] = new SelectList(_context.SaleCodes, "Id", "Code", managementSaleCode.SaleCodeId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName", managementSaleCode.UserId);
            return View(managementSaleCode);
        }

        // POST: ManagementSaleCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,SaleCodeId,Status")] ManagementSaleCode managementSaleCode)
        {
            if (id != managementSaleCode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(managementSaleCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManagementSaleCodeExists(managementSaleCode.Id))
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
            ViewData["SaleCodeId"] = new SelectList(_context.SaleCodes, "Id", "Code", managementSaleCode.SaleCodeId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName", managementSaleCode.UserId);
            return View(managementSaleCode);
        }

        // GET: ManagementSaleCodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var managementSaleCode = await _context.ManagementSaleCodes
                .Include(m => m.SaleCode)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (managementSaleCode == null)
            {
                return NotFound();
            }

            return View(managementSaleCode);
        }

        // POST: ManagementSaleCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var managementSaleCode = await _context.ManagementSaleCodes.FindAsync(id);
            _context.ManagementSaleCodes.Remove(managementSaleCode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManagementSaleCodeExists(int id)
        {
            return _context.ManagementSaleCodes.Any(e => e.Id == id);
        }
    }
}
