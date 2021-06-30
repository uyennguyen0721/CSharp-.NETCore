using System;
using System.Collections.Generic;

#nullable disable

namespace Entity_Models.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public DateTime? OrderDate { get; set; }
        public Shipper Shipper { get; set; }
    }
}
