using ASP_Razor_Partial.Models;
using ASP_Razor_Partial.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Razor_Partial.Pages.Shared.Components.ProductBox
{
    //[ViewComponent]
    public class ProductBox : ViewComponent
    {
        //Điều kiện (1): phải có một trong 2 phương thức có tên Invoke(object m) (trả về kiểu string (hoặc IViewComponentResult)) hoặc InvokeAsync
        //Điều kiện (2): có [ViewComponent] hoặc tên tên lớp có hậu tố là ViewComponent hoặc kế thừa ViewComponent

        /*public string Invoke()
        {
            return "Nội dung của ProductBox";
        }*/

        /*public IViewComponentResult Invoke()
        {
            return View("Default1");  //phương thức View() này sẽ thi hành file .cshtml một view mặc định nếu không có tham số gì --> Default.cshtml
        }*/
        ProductListService productService;

        public ProductBox(ProductListService _product)
        {
            productService = _product;
        }

        public IViewComponentResult Invoke(bool sapxeptang = true)
        {
            List<Product> _products = null;
            if (sapxeptang)
            {
                _products = productService.products.OrderBy(p => p.Price).ToList();
            }
            else
            {
                _products = productService.products.OrderByDescending(p => p.Price).ToList();
            }
            return View<List<Product>>(_products);
        }
    }
}
