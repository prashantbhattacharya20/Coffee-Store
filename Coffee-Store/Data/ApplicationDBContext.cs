using Coffee_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace Coffee_Store.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) {
        
        }
        
        public DbSet<User> Users { get; set; }

        public DbSet<Menu> Menu { get; set; }

        public DbSet<Reservations> Reservations { get; set; }

        public DbSet<Cart> Cart { get; set; }

        public DbSet<CartItem> CartItem { get; set; }
    }
}
