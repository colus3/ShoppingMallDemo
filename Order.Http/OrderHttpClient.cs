using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApiClients.Order.Common;
using ApiClients.Order.Common.DTO;
using Microsoft.Extensions.Options;

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

            var body = new StringContent("", Encoding.UTF8, "application/json");

            using (var response = await httpClient.PostAsync($"{mOptions.OrderServiceBaseUrl}/", body))
            {
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<XOrder> GetOrder(long orderID)
        {
            var httpClient = mHttpClientFactory.CreateClient(nameof(OrderHttpClient));

            using (var response = await httpClient.GetAsync($"{mOptions.OrderServiceBaseUrl}/"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<XOrder>();
                }

                // Normally, you would log appriate errors and return proper error code here instead of returning null.
                return null;
            }
        }

        public async Task<List<XOrder>> GetOrdersByUserID(long userID)
        {
            var httpClient = mHttpClientFactory.CreateClient(nameof(OrderHttpClient));

            using (var response = await httpClient.GetAsync($"{mOptions.OrderServiceBaseUrl}/"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<XOrder>>();
                }

                // Normally, you would log appriate errors and return proper error code here instead of returning null.
                return null;
            }
        }
    }
}
