using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Dtos;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
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

        [HttpPost(Name = "CreateProduct")]
        public ActionResult<ProductDto> Create(ProductDto productDto)
        {
            var product = new Product { Name = productDto.Name, ImageURL = productDto.ImageURL };
            product = _productsService.Create(product);

            productDto.Id = product.Id;
            productDto.Name = product.Name;
            productDto.ImageURL = product.ImageURL;

            return Created($"api/user-words/{productDto.Id}", productDto);
        }

        [HttpPatch("{id:guid}", Name = "UpdateProduct")]
        public ActionResult<ProductDto> Update(Guid id, ProductDto productDto)
        {
            var product = new Product { Name = productDto.Name, ImageURL = productDto.ImageURL };
            product = _productsService.Update(id, product);

            productDto.Id = product.Id;
            productDto.Name = product.Name;
            productDto.ImageURL = product.ImageURL;

            return productDto;
        }

        [HttpDelete("{id:guid}", Name = "DeleteProduct")]
        public ActionResult Delete(Guid id)
        {
            var succeded = _productsService.Delete(id);
            return succeded
                ? NoContent()
                : NotFound();
        }
    }
}