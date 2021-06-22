using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFramework
{
    [Table("Product")]
    public class Product
    {
        [Key] // thiết lập khóa chính
        public int ProductID { set; get; }

        [Required] // thiết lập trường dữ liệu ProductName khác null
        [StringLength(50)] // thiết lập chiều dài tối đa 50 kí tự
        public string ProductName { set; get; }

        [StringLength(50)]
        public string Provider { set; get; }
    }
}
