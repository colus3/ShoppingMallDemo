using Product.Common.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Common
{
    public interface IProductClient
    {
        Task<List<XProduct>> GetProducts();

        Task<XProduct> GetProduct(long id);
    }
}
