using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Middleware.Middleware
{
    public class FirstMiddleware
    {
        private readonly RequestDelegate _next;
        // RequestDelegate ~ async (HttpContext context) => {}
        public FirstMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // HttpContext đi qua Middleware trong pipeline
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"URL: {context.Request.Path}");
            context.Items.Add("DataFirstMiddleware", $"<p>URL: {context.Request.Path}</p>");
            //await context.Response.WriteAsync($"<p>URL: {context.Request.Path}</p>");

            // Chuyển HttpContext cho các Middleware phía sau
            await _next(context); // --> Nếu không chuyển thì nó sẽ như một Terminal Middleware 
        }
    }
}
