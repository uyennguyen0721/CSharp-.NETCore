using ASP_IServiceCollection_MapWhen.Options;
using ASP_IServiceCollection_MapWhen.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_IServiceCollection_MapWhen.Middleware
{
    public class TestOptionsMiddleware : IMiddleware
    {
        private object productNames;

        TestOptions _testOptions { set; get; }
        ProductNames _productNames { set; get; }

        public TestOptionsMiddleware(IOptions<TestOptions> options, ProductNames product)
        {
            _testOptions = options.Value;
            _productNames = product;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Show options in TestOptionsMiddleware\n");

            var stringBuilder = new StringBuilder();

            stringBuilder.Append($"TESTOPTIONS \nopt_key1 = {_testOptions.opt_key1}\n" +
                $"TestOptions.opt_key2.k1 = {_testOptions.opt_key2.k1} \nTestOptions.opt_key2.k2 = {_testOptions.opt_key2.k2}\n");

            foreach(var prName in _productNames.GetNames())
            {
                stringBuilder.Append(prName + "\n");
            }

            await context.Response.WriteAsync(stringBuilder.ToString());
            await next(context);
        }
    }
}
