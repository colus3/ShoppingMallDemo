using System.Collections.Generic;
using System.Threading.Tasks;
using Product.Common;
using Product.Common.DTO;

namespace Product.Direct
{
    public sealed class ProductDirectClient : IProductClient
    {
        public Task<XProduct> GetProduct(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<XProduct>> GetProducts()
        {
            throw new System.NotImplementedException();
        }
    }
}
