using ApiClients.Product.Common.DTO;
using Microsoft.EntityFrameworkCore;
using Services.Product.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Product
{
    public sealed class ProductService
    {
        private readonly ProductDbContext mDbContext;

        public ProductService(ProductDbContext dbContext)
        {
            mDbContext = dbContext;
        }

        public async Task<List<XProduct>> GetProductsAsync()
        {
            var products = await mDbContext.Products.AsNoTracking().ToListAsync();

            return products.Select(p => new XProduct
            (
                id: p.ID,
                name: p.Name,
                price: p.Price.Value
            )).ToList();
        }

        public async Task<XProduct> GetProductOrNullAsync(long ID)
        {
            var product = await mDbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.ID == ID);

            if (product == null)
            {
                return null;
            }

            return new XProduct(
                id: product.ID,
                name: product.Name,
                price: product.Price.Value
            );
        }
    }
}
