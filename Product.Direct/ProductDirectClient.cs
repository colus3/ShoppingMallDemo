using ApiClients.Product.Common;
using ApiClients.Product.Common.DTO;
using Services.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiClients.Product.Direct
{
    public sealed class ProductDirectClient : IProductClient
    {
        private readonly ProductService mProductService;

        public ProductDirectClient(ProductService productService)
        {
            mProductService = productService;
        }

        public async Task<XProduct> GetProductAsync(long id)
        {
            return await mProductService.GetProductOrNullAsync(id);
        }

        public async Task<List<XProduct>> GetProductsAsync()
        {
            return await mProductService.GetProductsAsync();
        }
    }
}
