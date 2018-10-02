using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApiClients.Order.Common;
using ApiClients.Order.Common.DTO;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ApiClients.Order.Http
{
    public sealed class OrderHttpClient : IOrderClient
    {
        private readonly IHttpClientFactory mHttpClientFactory;
        private readonly OrderServiceOptions mOptions;

        public OrderHttpClient(IHttpClientFactory httpClientFactory, IOptionsSnapshot<OrderServiceOptions> options)
        {
            mHttpClientFactory = httpClientFactory;
            mOptions = options.Value;
        }

        public async Task<bool> AddOrderAsync(XAddOrderRequest request)
        {
            var httpClient = mHttpClientFactory.CreateClient(nameof(OrderHttpClient));

            var body = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            using (var response = await httpClient.PostAsync($"{mOptions.OrderServiceBaseUrl}/Api/Internal/Orders", body))
            {
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<XOrder> GetOrder(long orderID)
        {
            var httpClient = mHttpClientFactory.CreateClient(nameof(OrderHttpClient));

            using (var response = await httpClient.GetAsync($"{mOptions.OrderServiceBaseUrl}/Api/Internal/Orders/{orderID}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<XOrder>();
                }

                // Normally, you would log appropriate errors and return proper error code here instead of returning null.
                return null;
            }
        }

        public async Task<List<XOrder>> GetOrdersByUserID(long userID)
        {
            var httpClient = mHttpClientFactory.CreateClient(nameof(OrderHttpClient));

            using (var response = await httpClient.GetAsync($"{mOptions.OrderServiceBaseUrl}/Api/Internal/Orders/ByUserID/{userID}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<XOrder>>();
                }

                // Normally, you would log appropriate errors and return proper error code here instead of returning null.
                return null;
            }
        }
    }
}
