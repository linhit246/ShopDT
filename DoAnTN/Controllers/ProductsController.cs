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

namespace DoAnTN.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopDienThoaiContext _context;
        private readonly IpaginationService _page;


        public ProductsController(ShopDienThoaiContext context, IpaginationService pages)
        {
            _context = context;
            _page = pages;
        }

        // GET: Products
        //public async Task<IActionResult> Index(int? page)
        //{
        //    if (page == null)
        //    {
        //        page = 1;
        //    }
        //    int pageSize = 10;
        //    int pageNumber = (page ?? 1);
        //    var shopDienThoaiContext = _context.Products.Include(p => p.Category).OrderByDescending(x => x.LastUpdate).Where(x => x.IsDelete == false);
        //    return View(shopDienThoaiContext.ToPagedList(pageNumber, pageSize));
        //}


        public IActionResult Index(int? page = 0)
        {
            int limit = 5;
            int start;
            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }
            start = (int)(page - 1) * limit;

            ViewBag.pageCurrent = page;

            int totalProduct = _page.totalProduct();

            ViewBag.totalProduct = totalProduct;

            ViewBag.numberPage = _page.numberPage(totalProduct, limit);

            var data = _page.paginationProduct(start, limit);

            return View(data);
        }


    public async Task<IActionResult> IndexClient()
        {
           
            var shopDienThoaiContext = _context.Products.Include(p => p.Category).OrderByDescending(x => x.LastUpdate).Where(x => x.IsDelete == false).Take(8);
            return View(await shopDienThoaiContext.ToListAsync());
        }
        public async Task<IActionResult> IndexClientAll()
        {
            var shopDienThoaiContext = _context.Products.Include(p => p.Category).OrderByDescending(x => x.LastUpdate).Where(x => x.IsDelete == false);
            return View(await shopDienThoaiContext.ToListAsync());
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CategoryId,ImagePath,SellCost,IsDelete,IsDisplay,LastUpdate")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
