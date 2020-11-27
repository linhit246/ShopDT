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
    public class CodeTypesController : Controller
    {
        private readonly ShopDienThoaiContext _context;

        public CodeTypesController(ShopDienThoaiContext context)
        {
            _context = context;
        }

        // GET: CodeTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CodeTypes.ToListAsync());
        }

        // GET: CodeTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeType = await _context.CodeTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (codeType == null)
            {
                return NotFound();
            }

            return View(codeType);
        }

        // GET: CodeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CodeTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,IsDelete,IsDisplay,LastUpdate")] CodeType codeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(codeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(codeType);
        }

        // GET: CodeTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeType = await _context.CodeTypes.FindAsync(id);
            if (codeType == null)
            {
                return NotFound();
            }
            return View(codeType);
        }

        // POST: CodeTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,IsDelete,IsDisplay,LastUpdate")] CodeType codeType)
        {
            if (id != codeType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(codeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodeTypeExists(codeType.Id))
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
            return View(codeType);
        }

        // GET: CodeTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeType = await _context.CodeTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (codeType == null)
            {
                return NotFound();
            }

            return View(codeType);
        }

        // POST: CodeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var codeType = await _context.CodeTypes.FindAsync(id);
            _context.CodeTypes.Remove(codeType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CodeTypeExists(int id)
        {
            return _context.CodeTypes.Any(e => e.Id == id);
        }
    }
}
