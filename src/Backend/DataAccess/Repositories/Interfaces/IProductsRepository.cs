using DataAccess.Entities;
using System.Collections.Generic;

namespace DataAccess.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        List<ProductEntity> GetAll();
    }
}
