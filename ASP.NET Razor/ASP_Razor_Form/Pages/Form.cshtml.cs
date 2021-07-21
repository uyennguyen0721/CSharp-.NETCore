using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASP_Razor_Form;

namespace ASP_Razor_Form.Pages
{
    public class FormModel : PageModel
    {
        public string Mesage { set; get; }
        [BindProperty]
        public CustomerInfo customerInfo { set; get; }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Mesage = "Dữ liệu Post chính xác";
                // Xử lý, chuyển hướng ...
            }
            else
            {
                Mesage = "Lỗi dữ liệu";
            }
        }
    }
}
