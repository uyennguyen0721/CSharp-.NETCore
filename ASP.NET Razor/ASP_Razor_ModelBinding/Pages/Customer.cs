using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Razor_ModelBinding.Pages
{
    [Bind("Email", "UserName")] // chỉ binding 2 thuộc tính Email và UserName của lớp Customer
    public class Customer
    {
        [BindRequired]
        public int CustomerID { set; get; }
        public string Email { set; get; }
        public string UserName { set; get; }
    }
}
