

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BakeTRy.Models
{
    public class BaketryDBContext : IdentityDbContext
    {
        public BaketryDBContext(DbContextOptions<BaketryDBContext> options) : base(options)
        {

        }

        public DbSet<Pastry> Pastries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
