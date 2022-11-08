using BusinessLogic.Exceptions;
using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Dtos;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet(Name = "GetProducts")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiError))]
        public ActionResult<IEnumerable<ProductDto>> GetAll()
        {
            var products = _productsService.GetAll();

            var productsDto = products
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageId = x.ImageId,
                })
                .ToList();

            return Ok(productsDto);
        }

        [HttpPost(Name = "CreateProduct")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiError))]
        public ActionResult<ProductDto> Create(ProductDto productDto)
        {
            if (string.IsNullOrEmpty(productDto.Name) || productDto.Id == default || productDto.ImageId == default)
            {
                throw new ValidationException("Not all object fields are filled");
            }

            var product = new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                ImageId = productDto.ImageId
            };

            _productsService.Create(product);

            return Created($"api/products/{productDto.Id}", productDto);
        }

        [HttpPut("{id:guid}", Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiError))]
        public ActionResult<ProductDto> Update(Guid id, ProductDto productDto)
        {
            if (string.IsNullOrEmpty(productDto.Name) || productDto.Id == default || productDto.ImageId == default)
            {
                throw new ValidationException("Not all object fields are filled");
            }

            var product = new Product { Name = productDto.Name, ImageId = productDto.ImageId };
            product = _productsService.Update(id, product);

            productDto.Id = product.Id;
            productDto.Name = product.Name;
            productDto.ImageId = product.ImageId;

            return productDto;
        }

        [HttpDelete("{id:guid}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiError))]
        public ActionResult Delete(Guid id)
        {
            if (id == default)
            {
                throw new ValidationException("Wrong id");
            }
            var succeded = _productsService.Delete(id);
            return succeded
                ? NoContent()
                : NotFound();
        }
    }
}