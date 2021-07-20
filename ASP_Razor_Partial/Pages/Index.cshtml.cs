using ASP_Razor_Partial.Pages.Shared.Components.MessagePage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Razor_Partial.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPost()
        {
            var username = this.Request.Form["username"];
            var message = new MessagePage.Message();
            message.title = "Thông báo";
            message.htmlcontent = $"Cảm ơn {username} đã gửi thông tin";
            message.secondwait = 2;
            message.urlredirect = Url.Page("Privacy");
            return ViewComponent("MessagePage", message);

        }
        /*
        public IActionResult OnGet()
        {
            
             Trong PageModel ta có thể trả về một Partial, ViewComponent
             Trong Controller (MVC): PartialView, ViewComponent
             

            return ViewComponent("ProductBox", false);
        }*/
    }
}
