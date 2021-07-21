using System;
using System.Collections.Generic;

#nullable disable

namespace Entity_Models.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Supplier Supplier { get; set; }
        public Category Category { get; set; }
        public string Unit { get; set; }
        public decimal? Price { get; set; }

        public void PrintInfo() => Console.WriteLine($"{ProductId} - {ProductName} - {Price} {Unit}");
    }
}
