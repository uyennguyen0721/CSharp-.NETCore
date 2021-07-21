using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Razor_Form
{
    public class CustomerInfo
    {
        [Required(ErrorMessage = "Phải có tên")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Chiều dài không chính xác")]
        [Display(Name = "TÊN KHÁCH")] // Label hiện thị
        [ModelBinder(BinderType = typeof(MyCheckNameBinding))]  // Khi binding dữ liệu sẽ chuyển in hoa, không chứa XXX
        public string Customername { set; get; }

        [Required]
        [EmailAddress]
        [Display(Name = "EMAIL")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Thiếu năm sinh")]
        [Display(Name = "NĂM SINH")]
        [Range(1970, 2000, ErrorMessage = "Khoảng năm sinh sai")]
        [MyValidation]
        public int? YearOfBirth { set; get; }
    }
}
