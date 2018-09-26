using Microsoft.EntityFrameworkCore;

namespace Services.Product.Data
{
    public sealed class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Models.Entity.Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
