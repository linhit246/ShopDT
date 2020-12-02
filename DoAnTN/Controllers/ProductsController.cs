using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnTN.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.FileProviders;
using DoAnTN.Helpers;
using PagedList.Core;
using System.Linq.Dynamic.Core;

namespace DoAnTN.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopDienThoaiContext _context;


        public ProductsController(ShopDienThoaiContext context)
        {
            _context = context;
        }

        //GET: Products
        public async Task<IActionResult> Index(int? page, string? searchString)
        {
            if (page == null)
            {
                page = 1;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var shopDienThoaiContext = _context.Products.Include(p => p.Category).OrderByDescending(x => x.LastUpdate).Where(x => x.IsDelete == false && x.Category.IsDelete == false);
            if (!String.IsNullOrEmpty(searchString))
            {
                var onePage = shopDienThoaiContext.Where(x => x.Name.Contains(searchString)).ToPagedList(pageNumber, pageSize);
                return View(onePage);
            }
            else
            {
                var onePage = shopDienThoaiContext.ToPagedList(pageNumber, pageSize);
                return View(onePage);
            }
        }
        public async Task<IActionResult> IndexClient(int? page, string? searchString)
        {
            ViewBag.Categories = new ProductDetailDAO().ListCategory();
            if (page == null)
            {
                page = 1;
            }
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var shopDienThoaiContext = _context.Products.Include(p => p.Category).OrderByDescending(x => x.LastUpdate).Where(x => x.IsDelete == false && x.Category.IsDelete == false);
            if (!String.IsNullOrEmpty(searchString))
            {
                var onePage = shopDienThoaiContext.Where(x => x.Name.Contains(searchString)).ToPagedList(pageNumber, pageSize);
                return View(onePage);
            }
            else
            {
                var onePage = shopDienThoaiContext.ToPagedList(pageNumber, pageSize);
                return View(onePage);
            }
        }
        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CategoryId,ImagePath,SellCost,IsDelete,IsDisplay,LastUpdate")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                Product p = new Product();
                p.Name = productDTO.Name;
                p.CategoryId = productDTO.CategoryId;
                p.ImagePath = UploadedFile(productDTO.ImagePath);
                p.SellCost = productDTO.SellCost;
                _context.Add(p);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", productDTO.CategoryId);
            return View(productDTO);
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
                var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image")).Root + $@"\{newFileName}";
                using (FileStream fs = System.IO.File.Create(filepath))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
            return newFileName;
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.id = id;
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewBag.Products = product;
            return View();
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var p = await _context.Products.FindAsync(id);
                    p.Name = productDTO.Name;
                    p.CategoryId = productDTO.CategoryId;
                    p.ImagePath = UploadedFile(productDTO.ImagePath);
                    p.SellCost = productDTO.SellCost;
                    _context.Update(p);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(id))
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
            var product = await _context.Products.FindAsync(id);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _ = product.IsDelete = true;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
