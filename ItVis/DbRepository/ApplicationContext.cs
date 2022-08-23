using ItVis.Models;
using ItVis.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace ItVis.DbRepository
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserAccount> UsersAccount { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductType> ProductTypes { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<ProductProperty> ProductsProperties { get; set; } = null!;
        public DbSet<Cart>? Carts { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReviewViewModel>()
                .Property(r => r.UserName)
                .HasDefaultValueSql();
        }
    }
}
