using DoAnTN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTN.Helpers
{
    public class paginationService : IpaginationService
    {
        private readonly ShopDienThoaiContext _db;
        private List<Product> products = new List<Product>();
        public paginationService(ShopDienThoaiContext db)
        {
            _db = db;
            this.products = _db.Products.ToList();
        }
        public IEnumerable<Product> getProductAll()
        {
            return products;
        }
        public int totalProduct()
        {
            return products.Count;
        }
        public int numberPage(int totalProduct, int limit)
        {
            float numberpage = totalProduct / limit;
            return (int)Math.Ceiling(numberpage);
        }
        public IEnumerable<Product> paginationProduct(int start, int limit)
        {
            var data = (from s in _db.Products select s);
            var dataProduct = data.OrderByDescending(x => x.Id).Skip(start).Take(limit);
            return dataProduct.ToList();
        }

    }
}
