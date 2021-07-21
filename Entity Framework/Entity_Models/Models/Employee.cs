using System;
using System.Collections.Generic;

#nullable disable

namespace Entity_Models.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Photo { get; set; }
        public string Notes { get; set; }
    }
}
