using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_IServiceCollection_MapWhen.Services
{
    public class ProductNames
    {
        private List<string> names { set; get; }
        public ProductNames()
        {
            names = new List<string>()
            {
                "Iphone 7", "Samsung G7", "Nokia 123"
            };
        }
        public List<string> GetNames() => names;
    }
}
