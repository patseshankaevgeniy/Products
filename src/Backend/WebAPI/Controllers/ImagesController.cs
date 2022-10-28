using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/images")]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imagesService;

        public ImagesController(IImageService imagesService)
        {
            _imagesService = imagesService;
        }

        [HttpGet("{id:guid}", Name = "GetImage")]
        public ActionResult Get(Guid id)
        {
            var image = _imagesService.Get(id);
            return File(image, "image/jpeg");
        }

        [HttpDelete("{id:guid}", Name = "GetImage")]
        public ActionResult Delete(Guid id)
        {
            var succeded = _imagesService.Delete(id);
            return succeded
                ? NoContent()
                : NotFound();
        }
    }
}
