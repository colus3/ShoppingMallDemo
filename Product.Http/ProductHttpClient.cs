using ApiClients.Product.Common;
using ApiClients.Product.Common.DTO;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiClients.Product.Http
{
    public sealed class ProductHttpClient : IProductClient
    {
        private readonly IHttpClientFactory mHttpClientFactory;
        private readonly ProductServiceOptions mOptions;

        public ProductHttpClient(IHttpClientFactory httpClientFactory, IOptionsSnapshot<ProductServiceOptions> options)
        {
            mHttpClientFactory = httpClientFactory;
            mOptions = options.Value;
        }

        public async Task<XProduct> GetProductAsync(long id)
        {
            var httpClient = mHttpClientFactory.CreateClient(nameof(ProductHttpClient));

            using (var response = await httpClient.GetAsync($"{mOptions.ProductServiceBaseUrl}/Api/Internal/Products/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<XProduct>();
                }

                // Normally, you would log appropriate errors and return proper error code here instead of returning null.
                return null;
            }
        }

        public async Task<List<XProduct>> GetProductsAsync()
        {
            var httpClient = mHttpClientFactory.CreateClient(nameof(ProductHttpClient));

            using (var response = await httpClient.GetAsync($"{mOptions.ProductServiceBaseUrl}/Api/Internal/Products"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<XProduct>>();
                }

                // Normally, you would log appropriate errors and return proper error code here instead of returning null.
                return null;
            }
        }
    }
}
