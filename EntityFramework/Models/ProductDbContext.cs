using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace EntityFramework
{
    public class ProductDbContext : DbContext
    {
        //Tạo bảng trong CSDL
        public DbSet<Product> products { set; get; }
                                                  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;user id=root;password=123456789;port=3306;database=entity;");
            }
        }
    }
}