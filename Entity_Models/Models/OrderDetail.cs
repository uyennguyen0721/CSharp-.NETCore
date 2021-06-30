using System;
using System.Collections.Generic;

#nullable disable

namespace Entity_Models.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int? Quantity { get; set; } //"?" -> thuộc tính này có thể bằng null
    }
}
