using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Register_Login_Logout.Models
{
    public class AppUser : IdentityUser
    {
        // Khai báo thêm các thuộc tính ngoài các thuộc
        // tính như UserName, Email ... cung cấp sẵn bởi IdentityUser

        [MaxLength(100)]
        public string FullName { set; get; }
        [MaxLength(255)]
        public string Address { set; get; }
        [DataType(DataType.Date)]
        public DateTime? Birthday { set; get; }
    }
}
