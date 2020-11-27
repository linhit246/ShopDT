using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnTN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoAnTN.Helpers;

namespace DoAnTN.Controllers
{
    public class CartController : Controller
    {
        private readonly ShopDienThoaiContext _context;

        public CartController(ShopDienThoaiContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<OrderDetailDTO> cart = SessionHelper.GetSession<List<OrderDetailDTO>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            if (cart != null)
            {
                ViewBag.total = cart.Sum(x => x.Quantity * x.SellCost);
            }
            else
            {
                ViewBag.total = 0;
            }
            return View(cart);
        }
        private int IsExits(int id)
        {
            List<OrderDetailDTO> orderDetail = SessionHelper.GetSession<List<OrderDetailDTO>>(HttpContext.Session, "cart");
            for (int i = 0; orderDetail.Count > i; i++)
            {
                if (orderDetail[i].ProductDetailID.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        public IActionResult BuyProducts(int id)
        {
            var p = _context.ProductDetails.Where(x => x.Id == id).Include(x => x.Product).FirstOrDefault();
            if (SessionHelper.GetSession<List<OrderDetailDTO>>(HttpContext.Session, "cart") == null)
            {
                List<OrderDetailDTO> cart = new List<OrderDetailDTO>();
                cart.Add(new OrderDetailDTO
                {
                    ProductDetailID = p.Id,
                    ProductName = p.Product.Name,
                    ProductColor = p.ProductColor,
                    ImagePath = p.ImagePath,
                    SellCost = p.Product.SellCost,
                    Quantity = 1
                });
                SessionHelper.SetSession(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<OrderDetailDTO> cart = SessionHelper.GetSession<List<OrderDetailDTO>>(HttpContext.Session, "cart");
                int index = IsExits(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new OrderDetailDTO
                    {
                        ProductDetailID = p.Id,
                        ProductName = p.Product.Name,
                        ProductColor = p.ProductColor,
                        ImagePath = p.ImagePath,
                        SellCost = p.Product.SellCost,
                        Quantity = 1
                    });
                }
                SessionHelper.SetSession(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        public IActionResult BuyProductsUp(int id)
        {
            var p = _context.ProductDetails.Where(x => x.Id == id).Include(x => x.Product).FirstOrDefault();
            List<OrderDetailDTO> cart = SessionHelper.GetSession<List<OrderDetailDTO>>(HttpContext.Session, "cart");
            int index = IsExits(id);
            if (index != -1)
            {
                cart[index].Quantity++;
            }

            SessionHelper.SetSession(HttpContext.Session, "cart", cart);

            return RedirectToAction("Index");
        }

        public IActionResult BuyProductsDown(int id)
        {
            var p = _context.ProductDetails.Where(x => x.Id == id).Include(x => x.Product).FirstOrDefault();
            List<OrderDetailDTO> cart = SessionHelper.GetSession<List<OrderDetailDTO>>(HttpContext.Session, "cart");
            int index = IsExits(id);
            if (index != -1)
            {
                if (cart[index].Quantity == 1)
                {
                    return RedirectToAction("Index");
                }
                else
                    cart[index].Quantity--;
            }

            SessionHelper.SetSession(HttpContext.Session, "cart", cart);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveProduct(int id)
        {
            List<OrderDetailDTO> cart = SessionHelper.GetSession<List<OrderDetailDTO>>(HttpContext.Session, "cart");
            int index = IsExits(id);
            cart.RemoveAt(index);
            SessionHelper.SetSession(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
    }
}
