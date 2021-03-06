﻿using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApiClients.Cart.Common;
using ApiClients.Cart.Common.DTO;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ApiClients.Cart.Http
{
    public sealed class CartHttpClient : ICartClient
    {
        private readonly IHttpClientFactory mHttpClientFactory;
        private readonly CartServiceOptions mOptions;

        public CartHttpClient(IHttpClientFactory httpClientFactory, IOptionsSnapshot<CartServiceOptions> options)
        {
            mHttpClientFactory = httpClientFactory;
            mOptions = options.Value;
        }

        public async Task<bool> AddCartItemAsync(long userID, XAddCartItemRequest request)
        {
            var httpClient = mHttpClientFactory.CreateClient(nameof(CartHttpClient));

            var body = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            using (var response = await httpClient.PostAsync($"{mOptions.CartServiceBaseUrl}/Api/Internal/Carts/{userID}", body))
            {
                // Normally, you would log appropriate errors and return proper error code here instead of true/false.

                return response.IsSuccessStatusCode;
            }
        }

        public async Task<XCart> GetCartByUserIDAsync(long userID)
        {
            var httpClient = mHttpClientFactory.CreateClient(nameof(CartHttpClient));

            using (var response = await httpClient.GetAsync($"{mOptions.CartServiceBaseUrl}/Api/Internal/Carts/ByUserID/{userID}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<XCart>();
                }

                // Normally, you would log appropriate errors and return proper error code here instead of returning null.
                return null;
            }
        }

        public async Task<bool> UpdateCartItemQuantityAsync(long userID, long cartItemID, XUpdateCartItemQuantityRequest request)
        {
            var httpClient = mHttpClientFactory.CreateClient(nameof(CartHttpClient));

            var body = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            using (var response = await httpClient.PatchAsync($"{mOptions.CartServiceBaseUrl}/Api/Internal/Carts/ByUserID/{userID}/CartItems/{cartItemID}", body))
            {
                // Normally, you would log appropriate errors and return proper error code here instead of true/false.
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> UpdateCartStatus(long userID, XUpdateCartStatusRequest request)
        {
            var httpClient = mHttpClientFactory.CreateClient(nameof(CartHttpClient));

            var body = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            using (var response = await httpClient.PatchAsync($"{mOptions.CartServiceBaseUrl}/Api/Internal/Carts/ByUserID/{userID}", body))
            {
                // Normally, you would log appropriate errors and return proper error code here instead of true/false.
                return response.IsSuccessStatusCode;
            }
        }
    }
}
