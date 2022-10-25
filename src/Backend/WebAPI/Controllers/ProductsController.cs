using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Dtos;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet(Name = "GetProducts")]
        public ActionResult<IEnumerable<ProductDto>> GetAll()
        {
            var products = _productsService.GetAll();

            var productsDto = products
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageURL = x.ImageURL,
                })
                .ToList();

            return Ok(productsDto);
        }
    }
}