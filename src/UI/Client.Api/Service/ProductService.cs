using Client.Api.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Client.Api.Service
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _cache;
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IConfiguration configuration, IMemoryCache cache, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _cache = cache;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var tokenCache = await _cache.Get<Task<TokenResponse>>("TokeAuthApi");
            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenCache.Token);
            var response = await client.GetAsync($"{_configuration["ProductsApi:Host"]}/products");
            response.EnsureSuccessStatusCode();

            var bodyResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(bodyResponse);

            return result;
        }
    }
}
