using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/images")]
    [Produces("application/json")]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imagesService;

        public ImagesController(IImageService imagesService)
        {
            _imagesService = imagesService;
        }

        [HttpGet("{id:guid}", Name = "GetImage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiError))]
        public ActionResult Get(Guid id)
        {
            var image = _imagesService.Get(id);
            return File(image, "image/jpeg");
        }

        [HttpPost("{id:guid}", Name = "CreateImage")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiError))]
        public ActionResult Create(Guid id, byte[] image)
        {
            _imagesService.Create(id, image);
            return File(image, "image/jpeg");
        }

        [HttpDelete("{id:guid}", Name = "DeleteImage")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiError))]
        public ActionResult Delete(Guid id)
        {
            var succeded = _imagesService.Delete(id);
            return succeded
                ? NoContent()
                : NotFound();
        }
    }
}
