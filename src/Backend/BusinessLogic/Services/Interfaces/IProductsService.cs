using BusinessLogic.Models;
using System.Collections.Generic;

namespace BusinessLogic.Services.Interfaces
{
    public interface IProductsService
    {
        List<Product> GetAll();

    }
}
