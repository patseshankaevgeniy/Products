using BusinessLogic.Models;
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

        public ProductsService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            using var httpClient = _httpClient.CreateClient();
            var products = await httpClient.GetFromJsonAsync<List<ProductDto>>("https://localhost:7159/api/products");
            return products;
        }

        public async Task DeleteProductsAsync(Guid id)
        {
            using var httpClient = _httpClient.CreateClient();
            await httpClient.DeleteAsync($"https://localhost:7159/api/products/{id}");
        }

        public async Task CreateProduct(ProductDto product)
        {
            var httpClient = _httpClient.CreateClient();
            await httpClient.PostAsJsonAsync("https://localhost:7159/api/products", product);
        }

    }
}
