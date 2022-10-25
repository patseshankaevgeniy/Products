using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public List<Product> GetAll()
        {
            var productEntities = _productsRepository.GetAll();

            return productEntities
                 .Select(x => new Product
                 {
                     Id = x.Id,
                     Name = x.Name,
                     ImageURL = ""
                 })
                 .ToList();
        }
    }
}
