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
    public class OrderDetailsController : Controller
    {
        private readonly ShopDienThoaiContext _context;

        public OrderDetailsController(ShopDienThoaiContext context)
        {
            _context = context;
        }

        // GET: OrderDetails
        public async Task<IActionResult> Index()
        {
            var shopDienThoaiContext = _context.OrderDetails.Include(o => o.Order).Include(o => o.ProductDetail);
            return View(await shopDienThoaiContext.ToListAsync());
        }

        public async Task<IActionResult> IndexDetail(int id)
        {
            var shopDienThoaiContext = _context.OrderDetails.Include(o => o.Order).Include(o => o.ProductDetail).Where(x => x.OrderId == id);
            return View(await shopDienThoaiContext.ToListAsync());
        }

        // GET: OrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.ProductDetail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
            ViewData["ProductDetailId"] = new SelectList(_context.ProductDetails, "Id", "Id");
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderId,ProductDetailId,Quantity,Total,IsDelete,IsDisplay,LastUpdate")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderDetail.OrderId);
            ViewData["ProductDetailId"] = new SelectList(_context.ProductDetails, "Id", "Id", orderDetail.ProductDetailId);
            return View(orderDetail);
        }
        public async Task<IActionResult> CreateOrderDetail(OrderDetailDTO orderDetailDTO)
        {
            if (ModelState.IsValid)
            {
                List<OrderDetailDTO> cart = SessionHelper.GetSession<List<OrderDetailDTO>>(HttpContext.Session, "cart");
                foreach (var item in cart)
                {
                    var od = _context.Orders.OrderByDescending(x => x.LastUpdate).FirstOrDefault();
                    OrderDetail o = new OrderDetail();
                    o.OrderId = od.Id;
                    o.ProductDetailId = item.ProductDetailID;
                    o.Quantity = item.Quantity;
                    o.Total = item.Quantity * item.SellCost;
                    _context.Add(o);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("IndexClient", "Products");
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
            ViewData["ProductDetailId"] = new SelectList(_context.ProductDetails, "Id", "Id");
            return View(orderDetailDTO);
        }

        // GET: OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderDetail.OrderId);
            ViewData["ProductDetailId"] = new SelectList(_context.ProductDetails, "Id", "Id", orderDetail.ProductDetailId);
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderId,ProductDetailId,Quantity,Total,IsDelete,IsDisplay,LastUpdate")] OrderDetail orderDetail)
        {
            if (id != orderDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailExists(orderDetail.Id))
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
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderDetail.OrderId);
            ViewData["ProductDetailId"] = new SelectList(_context.ProductDetails, "Id", "Id", orderDetail.ProductDetailId);
            return View(orderDetail);
        }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.ProductDetail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailExists(int id)
        {
            return _context.OrderDetails.Any(e => e.Id == id);
        }
    }
}
