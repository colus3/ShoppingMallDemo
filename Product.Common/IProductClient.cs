using ApiClients.Product.Common.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiClients.Product.Common
{
    public interface IProductClient
    {
        Task<List<XProduct>> GetProductsAsync();

        Task<XProduct> GetProductAsync(long id);
    }
}
