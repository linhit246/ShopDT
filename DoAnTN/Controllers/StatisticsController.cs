using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnTN.Models;
using System.Web;
using ClosedXML.Excel;
using System.IO;

namespace DoAnTN.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly ShopDienThoaiContext _context;

        public StatisticsController(ShopDienThoaiContext context)
        {
            _context = context;
        }

        // GET: Statistics
        public async Task<IActionResult> Index()
        {
            var shopDienThoaiContext = _context.Orders.Include(o => o.User);
            return View(await shopDienThoaiContext.ToListAsync());
        }

        public IActionResult ExportToExcel()
        {
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "BaoCao.xlsx";
            var shopDienThoaiContext = _context.Orders.Include(o => o.User);
            double tongtien = 0;
            foreach (var item in shopDienThoaiContext)
            {
                tongtien += item.Total;
            }
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet = workbook.Worksheets.Add("Orders");
                    worksheet.Style.Font.SetFontName("Times New Roman");
                    worksheet.Style.Font.SetFontSize(12);
                    worksheet.Cell(1, 1).Value = "STT";
                    worksheet.Cell(1, 2).Value = "Mã khách hàng";
                    worksheet.Cell(1, 3).Value = "Họ và tên";
                    worksheet.Cell(1, 4).Value = "Số điện thoại";
                    worksheet.Cell(1, 5).Value = "Địa chỉ";
                    worksheet.Cell(1, 6).Value = "Ngày đặt hàng";
                    //worksheet.Cell(1, 7).Value = "Ngày giao hàng";
                    //worksheet.Cell(1, 8).Value = "Trạng thái";
                    //worksheet.Cell(1, 9).Value = "Mã giảm giá";
                    worksheet.Cell(1, 7).Value = "Tổng tiền";
                    int i = 1;
                    foreach (var item in shopDienThoaiContext)
                    {
                        worksheet.Cell(i + 1, 1).Value = i;
                        worksheet.Cell(i + 1, 2).Value = item.UserId;
                        worksheet.Cell(i + 1, 3).Value = item.FullName;
                        worksheet.Cell(i + 1, 4).Value = "(+84)" + item.Phone;
                        worksheet.Cell(i + 1, 5).Value = item.Address;
                        worksheet.Cell(i + 1, 6).Value = item.OrderDate;
                        //worksheet.Cell(i + 1, 7).Value = item.ClosedDate;
                        //worksheet.Cell(i + 1, 8).Value = item.Status;
                        //worksheet.Cell(i + 1, 9).Value = item.SaleCodeId;
                        worksheet.Cell(i + 1, 7).Value = item.Total.ToString("#,###") + " đ";
                        i++;
                    }
                    worksheet.Cell(i + 1, 6).Value = "Doanh thu";
                    worksheet.Cell(i + 1, 7).Value = tongtien.ToString("#,###") + " đ";
                    worksheet.Cell(i + 1, 7).Style.Font.SetFontColor(XLColor.Red);
                    SetHeader(ref worksheet, i + 1, 6);
                    for (i = 1; i <= 10; i++)
                    {
                        SetHeader(ref worksheet, 1, i);
                    }
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, contentType, fileName);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SetHeader(ref IXLWorksheet worksheet, int i, int j)
        {
            worksheet.Cell(i, j).Style.Fill.SetBackgroundColor(XLColor.Gray);
            worksheet.Cell(i, j).Style.Font.SetFontColor(XLColor.White);
            worksheet.Cell(i, j).Style.Font.Bold = true;
            worksheet.Cell(i, i).Style.Font.SetFontSize(13);
            worksheet.Cell(i, j).Style.Font.SetFontName("Times New Roman");
        }

        // GET: Statistics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Statistics/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName");
            return View();
        }

        // POST: Statistics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,FullName,Phone,Address,OrderDate,ClosedDate,Status,SaleCodeId,Total,IsDelete,IsDisplay,LastUpdate")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName", order.UserId);
            return View(order);
        }

        // GET: Statistics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName", order.UserId);
            return View(order);
        }

        // POST: Statistics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,FullName,Phone,Address,OrderDate,ClosedDate,Status,SaleCodeId,Total,IsDelete,IsDisplay,LastUpdate")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName", order.UserId);
            return View(order);
        }

        // GET: Statistics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Statistics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
