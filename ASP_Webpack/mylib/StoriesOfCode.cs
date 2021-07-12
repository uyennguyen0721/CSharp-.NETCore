using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Webpack.mylib
{
    public static class StoriesOfCode
    {
        public static string Stories(HttpRequest resquest)
        {
            return "Những mẫu chuyện của Code";
        }
    }
}
