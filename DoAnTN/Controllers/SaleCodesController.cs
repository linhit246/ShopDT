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
    public class SaleCodesController : Controller
    {
        private readonly ShopDienThoaiContext _context;

        public SaleCodesController(ShopDienThoaiContext context)
        {
            _context = context;
        }

        // GET: SaleCodes
        public async Task<IActionResult> Index()
        {
            var shopDienThoaiContext = _context.SaleCodes.Include(s => s.CodeType);
            return View(await shopDienThoaiContext.ToListAsync());
        }

        // GET: SaleCodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleCode = await _context.SaleCodes
                .Include(s => s.CodeType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleCode == null)
            {
                return NotFound();
            }

            return View(saleCode);
        }

        // GET: SaleCodes/Create
        public IActionResult Create()
        {
            ViewData["CodeTypeId"] = new SelectList(_context.CodeTypes, "Id", "Name");
            return View();
        }

        // POST: SaleCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodeTypeId,Code,ConditionSale,StartDate,ClosedDate,Quantity,Description,Sale,IsDelete,IsDisplay,LastUpdate")] SaleCode saleCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodeTypeId"] = new SelectList(_context.CodeTypes, "Id", "Name", saleCode.CodeTypeId);
            return View(saleCode);
        }

        // GET: SaleCodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleCode = await _context.SaleCodes.FindAsync(id);
            if (saleCode == null)
            {
                return NotFound();
            }
            ViewData["CodeTypeId"] = new SelectList(_context.CodeTypes, "Id", "Name", saleCode.CodeTypeId);
            return View(saleCode);
        }

        // POST: SaleCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodeTypeId,Code,ConditionSale,StartDate,ClosedDate,Quantity,Description,Sale,IsDelete,IsDisplay,LastUpdate")] SaleCode saleCode)
        {
            if (id != saleCode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleCodeExists(saleCode.Id))
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
            ViewData["CodeTypeId"] = new SelectList(_context.CodeTypes, "Id", "Name", saleCode.CodeTypeId);
            return View(saleCode);
        }

        // GET: SaleCodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleCode = await _context.SaleCodes
                .Include(s => s.CodeType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleCode == null)
            {
                return NotFound();
            }

            return View(saleCode);
        }

        // POST: SaleCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleCode = await _context.SaleCodes.FindAsync(id);
            _context.SaleCodes.Remove(saleCode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleCodeExists(int id)
        {
            return _context.SaleCodes.Any(e => e.Id == id);
        }
    }
}
