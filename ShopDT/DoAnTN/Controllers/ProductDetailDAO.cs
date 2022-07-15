using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTN.Models
{
    public class ProductDetailDAO
    {
        ShopDienThoaiContext _context = null;
        public ProductDetailDAO()
        {
            _context = new ShopDienThoaiContext();
        }
        public List<ProductDetail> ListProductDetail(int id)
        {
            var product = _context.ProductDetails.Where(x => x.ProductId == id);
            return product.ToList();
        }

        public List<Category> ListCategory()
        {
            var category = _context.Categories;
            return category.ToList();
        }
        public Product ListProduct(int id)
        {
            var product = _context.Products.Find(id);
            return product;
        }
    }
}
