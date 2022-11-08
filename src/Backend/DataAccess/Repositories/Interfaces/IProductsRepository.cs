using DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        List<ProductEntity> GetAll();
        ProductEntity Create(ProductEntity product);
        ProductEntity Update(Guid id, ProductEntity product);
        bool Delete(Guid id);
    }
}
