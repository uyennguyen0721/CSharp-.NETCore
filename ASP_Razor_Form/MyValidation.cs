using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Razor_Form
{
    public class MyValidation : ValidationAttribute
    {
        public MyValidation()
        {
            ErrorMessage = "Không phải số chẵn";
        }

        public override bool IsValid(object value)
        {
            if (value == null) return false;
            int number = Int32.Parse(value.ToString());
            bool chiahetcho2 = number % 2 == 0;
            return chiahetcho2;

        }
    }
}
