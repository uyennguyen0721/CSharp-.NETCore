using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Razor_ModelBinding.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        // Binding Email từ dữ liệu từ nguồn tới có tên Email, email, emaIL ...
        [BindProperty]
        public string Email { get; set; }

        // Binding cho UserId từ nguồn gửi đến, dữ liệu nguồn có tên username
        [BindProperty(Name = "username")]
        public string UserId { set; get; }

        // Binding ProductID - thiết lập BINDING ngay cả khi truy cập là HTTP GÉT
        [BindProperty(SupportsGet = true)]
        public int ProductID { set; get; }

        // Binding Color
        [BindProperty]
        public string Color { set; get; }

        [BindProperty(SupportsGet = true)]
        public Customer customer { set; get; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(int? productID, string color)
        {
            Console.WriteLine($"ProductID: {productID}; color: {color}");
        }
        // Handler gọi khi truy vấn bằng HTTP POST
        public void OnPost()
        {
            // Microsoft.AspNetCore.Http.Extensions -> GetDisplayUrl
            Console.WriteLine(Request.GetDisplayUrl());
            var req = Request;
        }
    }
}
