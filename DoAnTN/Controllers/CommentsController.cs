﻿using System;
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
    public class CommentsController : Controller
    {
        private readonly ShopDienThoaiContext _context;

        public CommentsController(ShopDienThoaiContext context)
        {
            _context = context;
        }

        // GET: Comments
        public async Task<IActionResult> Index()
        {
            var shopDienThoaiContext = _context.Comments.Include(c => c.Product).Include(c => c.User).OrderByDescending(x => x.CommentDate);
            return View(await shopDienThoaiContext.ToListAsync());
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .Include(c => c.Product)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // GET: Comments/Create
        //public IActionResult Create()
        //{
        //    ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName");
        //    return View();
        //}

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        public async Task<IActionResult> Create(int id)
        {
            if (SessionHelper.GetSession<User>(HttpContext.Session, "Login") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            else
            {
                var user = SessionHelper.GetSession<User>(HttpContext.Session, "Login");
                Comment cm = new Comment();
                cm.UserId = user.Id;
                cm.ProductId = id;
                cm.Content = Request.Form["content"];
                _context.Add(cm);
                await _context.SaveChangesAsync();
                return RedirectToAction("IndexClient", "ProductDetails", new { @id = id });
            }
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", comment.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName", comment.UserId);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ProductId,Reliability,Content,CommentDate,ImagePath,Status")] Comment comment)
        {
            if (id != comment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", comment.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName", comment.UserId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .Include(c => c.Product)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
        public async Task<IActionResult> Accept(int id)
        {
            var order = await _context.Comments.FindAsync(id);
            order.Status = true;
            _context.Comments.Update(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
