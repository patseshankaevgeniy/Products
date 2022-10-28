using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using System;
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
                     ImageId = x.ImageId
                 })
                 .ToList();
        }

        public Product Create(Product product)
        {
            var productEntity = new ProductEntity
            {
                Id = product.Id,
                ImageId = product.ImageId,
                Name = product.Name,
            };

            _productsRepository.Create(productEntity);

            return product;
        }

        public Product Update(Guid id, Product product)
        {
            var productEntity = new ProductEntity
            {
                Id = id,
                ImageId = product.ImageId,
                Name = product.Name,
            };

            productEntity = _productsRepository.Update(id, productEntity);
            return product;
        }

        public bool Delete(Guid id)
        {
            var result = _productsRepository.Delete(id);
            return result;
        }
    }
}
