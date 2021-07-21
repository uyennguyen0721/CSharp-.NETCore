using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Razor_EntityFramework.Models
{
    public class Article
    {
        // ID sẽ là Primary Key khi lưu trong Db
        public int ID { get; set; }
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Ngày đăng")]

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [Display(Name = "Nội dung")]
        public string Content { set; get; }
    }
}
