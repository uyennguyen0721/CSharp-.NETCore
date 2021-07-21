using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Webpack
{
    public class Program
    {
        /*
        npm init -y                                         # tạo file package.json cho dự án
        npm i -D webpack webpack-cli                        # cài đặt Webpack
        npm i node-sass postcss-loader postcss-preset-env   # cài đặt các gói để làm việc với SCSS
        npm i sass-loader css-loader cssnano                # cài đặt các gói để làm việc với SCSS, CSS
        npm i mini-css-extract-plugin cross-env file-loader # cài đặt các gói để làm việc với SCSS
        npm install copy-webpack-plugin                     # cài đặt plugin copy file cho Webpack
        npm install npm-watch                               # package giám sát file  thay đổi


        npm install bootstrap                               # cài đặt thư viện bootstrap
        npm install jquery                                  # cài đặt Jquery
        npm install popper.js                               # thư viện cần cho bootstrap
         */
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
