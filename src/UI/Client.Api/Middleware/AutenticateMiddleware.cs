using Client.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Client.Api.Middleware
{
    public class AutenticateMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;

        public AutenticateMiddleware(RequestDelegate next, IMemoryCache cache, IConfiguration configuration)
        {
            _next = next;
            _cache = cache;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            var cacheEntry = _cache.GetOrCreate("TokeAuthApi", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                entry.SetPriority(CacheItemPriority.High);

                return GenerateToken();
            });

            await _next(context);
        }

        private async Task<TokenResponse> GenerateToken()
        {
            var httpClient = new HttpClient();
            var body = new
            {
                email = "wodsonluiz6@live.com",
                password = "joao123"
            };

            var content = JsonConvert.SerializeObject(body);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_configuration["AuthApi:Host"]}/authenticate/user-token"),
                Content = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Json)
            };

            var response = httpClient.Send(request);
            response.EnsureSuccessStatusCode();

            var bodyResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TokenResponse>(bodyResponse);

            return result;
        }
    }
}
