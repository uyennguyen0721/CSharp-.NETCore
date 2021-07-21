using ASP_Razor_Partial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Razor_Partial.Services
{
    public class ProductListService
    {
        public List<Product> products = new List<Product> {
                new Product() { Name = "Iphone X", Description = "Điện thoại Iphone của Apple", Price = 1000 },
                new Product() { Name = "Samsung Galaxy", Description = "Điện thoại Samsung Galaxy của Samsung", Price = 800 },
                new Product() { Name = "Nokia Lumia", Description = "Điện thoại Nokia Lumia của Nokia", Price = 500 }
        };
    }
}
