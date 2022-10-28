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
            
            var image = _imagesRepository.Get(id);
            if (image == null)
            {

            }
            
            return image;
        }

        public byte[] Create(Guid id, byte[] image)
        {
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
