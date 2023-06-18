using Microsoft.EntityFrameworkCore;
using OnlineShop230616.Models;

namespace OnlineShop230616.DAL
{
    public class OnlineShopDbContext : DbContext
    {
        public OnlineShopDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ProductModel> product { get; set; }
    }
}
