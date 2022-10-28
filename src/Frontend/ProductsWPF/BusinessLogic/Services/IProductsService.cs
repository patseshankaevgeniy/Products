using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IProductsService
    {
        Task<List<ProductDto>> GetProductsAsync();
        Task DeleteProductsAsync(Guid id);
        Task CreateProductAsync(string name, byte[] image);
    }
}