using BusinessLogic.Exceptions;
using BusinessLogic.Services.Interfaces;
using DataAccess.Repositories.Interfaces;
using System;

namespace BusinessLogic.Services
{
    public class ImageService : IImageService
    {
        private readonly IImagesRepository _imagesRepository;

        public ImageService(IImagesRepository repository)
        {
            _imagesRepository = repository;
        }

        public byte[] Get(Guid id)
        {
            if (id == null)
            {

            }
            var image = _imagesRepository.Get(id);
            if (image == null)
            {
                throw new NotFoundException($"There is no picture with id: {id}");
            }

            return image;
        }

        public byte[] Create(Guid id, byte[] image)
        {
            if (image == null)
            {
                throw new ValidationException("Image is empty");
            }
            _imagesRepository.Create(id, image);
            return image;
        }

        public bool Delete(Guid id)
        {
            var result = _imagesRepository.Delete(id);
            return result;
        }
    }
}
