using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Middleware.Middleware
{
    public class SecondMiddleware : IMiddleware
    {
        /* Khi HttpContext đi qua Middleware này thì nó kiểm tra URL (địa chỉ truy cập), nếu địa chỉ ấy là "xxx.html"
        thì nó sẽ không gọi Middleware phía sau đồng thời trả về phía Client một Respond có nội dung "Bạn không được 
        truy cập". Giả sử thiết lập một header trả về, tạo ra một header có tên là SecondMiddleware có nội dung của header
        đó là "Bạn không được truy cập". Nếu địa chỉ đó khác "xxx.html" thì nó chỉ tạo ra một header tên là SecondMiddleware
        và có nội dung là "Bạn được truy cập", sau đó nó thực hiện gọi ngay Middleware phía sau (chuyển HttpContext cho Middleware
        phía sau)
         */
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path == "/xxx.html")
            {
                context.Response.Headers.Add("SecondMiddleware", "Bạn không được truy cập");
                var datafromFirstMiddleware = context.Items["DataFirstMiddleware"];
                if (datafromFirstMiddleware != null)
                    await context.Response.WriteAsync((string)datafromFirstMiddleware);

                await context.Response.WriteAsync("Bạn không được truy cập");
            }
            else
            {
                context.Response.Headers.Add("SecondMiddleware", "Bạn được truy cập");
                var datafromFirstMiddleware = context.Items["DataFirstMiddleware"];
                if (datafromFirstMiddleware != null)
                    await context.Response.WriteAsync((string)datafromFirstMiddleware);
                await next(context);
            }
        }
    }
}
