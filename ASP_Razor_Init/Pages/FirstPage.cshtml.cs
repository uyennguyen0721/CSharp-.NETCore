using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_Razor_Init.Pages
{
    public class FirstPageModel : PageModel
    {
        public string title { set; get; } = "ĐÂY LÀ TRANG RAZOR CỦA UYÊN NGUYỄN";
        //OnGet, OnGetAbc, OnGetXyz, ...
        //OnPost(), OnPostAbc(), OnPostXyz(), ...
        // ---> Handler
        public void OnGet()
        {
            Console.WriteLine("Truy vấn bằng phương thức GET");
            ViewData["mydata"] = "Tracy - Uyên Nguyễn";
        }

        //GET, Url?handler=Xyz
        public void OnGetXyz()
        {
            Console.WriteLine("Truy vấn OnGetXyz");
            ViewData["mydata"] = "Tracy - Uyên Nguyễn XYZ";
        }

        public string Welcome(string name)
        {
            return $"Chào mừng {name} đến với website";
        }
    }
}
