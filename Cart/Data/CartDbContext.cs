using Microsoft.EntityFrameworkCore;

namespace Services.Cart.Data
{
    public sealed class CartDbContext : DbContext
    {
        public CartDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Models.Entity.Cart> Carts { get; set; }

        public DbSet<Models.Entity.CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Models.Entity.Cart>()
                .HasMany(c => c.CartItems)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartID);

            builder.Entity<Models.Entity.Cart>()
                .HasIndex(c => c.UserID)
                .IsUnique()
                .HasFilter("[Status] == 0");
        }
    }
}
