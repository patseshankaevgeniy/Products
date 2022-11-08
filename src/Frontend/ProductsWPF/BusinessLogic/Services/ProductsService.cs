using BusinessLogic.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly string _baseUrl;

        public ProductsService(IHttpClientFactory httpClient,
            IConfiguration configuration )
        {
            _baseUrl = configuration["BackendBaseUrl"];
            _httpClient = httpClient;
        }

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            using var httpClient = _httpClient.CreateClient();
            var products = await httpClient.GetFromJsonAsync<List<ProductDto>>($"{_baseUrl}/api/products");
            return products;
        }

        public async Task UpdateAsync(Guid id, ProductDto product)
        {
            using var httpClient = _httpClient.CreateClient();
            await httpClient.PutAsJsonAsync("https://localhost:7159/api/products", product);
        }

        public async Task CreateProductAsync(string name, byte[] image)
        {
            var product = new ProductDto
            {
                Id = Guid.NewGuid(),
                Name = name,
                ImageId = Guid.NewGuid()
            };

            using var httpClient = _httpClient.CreateClient();
            var result = await httpClient.PostAsJsonAsync($"https://localhost:7159/api/images/{product.ImageId}", image);
            if (result.IsSuccessStatusCode)
            {
                await httpClient.PostAsJsonAsync("https://localhost:7159/api/products", product);
            }
        }

        public async Task DeleteProductsAsync(Guid id)
        {
            using var httpClient = _httpClient.CreateClient();
            await httpClient.DeleteAsync($"https://localhost:7159/api/products/{id}");
        }
    }
}
