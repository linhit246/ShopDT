using DoAnTN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTN.Helpers
{
    public interface IpaginationService
    {
        IEnumerable<Product> getProductAll();
        int totalProduct();
        int numberPage(int totalProduct, int limit);
        IEnumerable<Product> paginationProduct(int start, int limit);

    }
}
