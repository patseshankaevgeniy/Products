using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private List<ProductEntity> _products;

        public ProductsRepository()
        {
            _products = new List<ProductEntity>
            {
                new ProductEntity{ Id = Guid.NewGuid(), Name = "First", ImageName = "FirstImage"},
                new ProductEntity{ Id = Guid.NewGuid(), Name = "Second", ImageName = "SecondImage"},
                new ProductEntity{ Id = Guid.NewGuid(), Name = "First", ImageName = "ThirdImage"}
            };
        }

        public List<ProductEntity> GetAll()
        {
            return _products;
        }
    }
}
