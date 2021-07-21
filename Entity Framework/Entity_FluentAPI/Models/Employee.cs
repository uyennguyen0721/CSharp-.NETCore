using System;
using System.Collections.Generic;

#nullable disable

namespace Entity_FluentAPI.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
        }

        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Photo { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
