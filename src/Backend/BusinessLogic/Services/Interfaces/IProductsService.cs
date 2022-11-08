using BusinessLogic.Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Services.Interfaces
{
    public interface IProductsService
    {
        List<Product> GetAll();
        Product Create(Product product);
        Product Update(Guid id,Product product);
        bool Delete(Guid id);
    }
}
