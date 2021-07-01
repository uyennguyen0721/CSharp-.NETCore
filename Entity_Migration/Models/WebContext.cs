using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_Migration.Models
{
    public class WebContext : DbContext
    {
        public DbSet<Article> articles { set; get; }        // bảng article
        public DbSet<Tag> tags { set; get; }                // bảng tag

        // chuỗi kết nối với tên db sẽ làm  việc đặt là webdb
        public const string ConnectStrring = @"Server=DESKTOP-3VODAHR\\SQLEXPRESS;Database=shopdata;Trusted_Connection=True;";

        private ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
                    builder.AddConsole()
                           .AddFilter(DbLoggerCategory.Database.Command.Name,
                                    LogLevel.Information));
            return serviceCollection.BuildServiceProvider()
                    .GetService<ILoggerFactory>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectStrring);
            optionsBuilder.UseLoggerFactory(GetLoggerFactory());       // bật logger
        }


    }
}
