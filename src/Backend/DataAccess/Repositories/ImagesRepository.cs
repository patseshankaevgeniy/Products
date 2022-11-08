using DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DataAccess.Repositories
{
    public class ImagesRepository : IImagesRepository
    {
        private readonly string imageFolderPath;

        public ImagesRepository(IConfiguration configuration)
        {
            imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), configuration["ImagesPath"]);
        }

        public byte[] Get(Guid id)
        {
            var filePath = Path.Combine(imageFolderPath, id.ToString() + ".jpg");
            var image = File.ReadAllBytes(filePath);

            return image;
        }

        public void Create(Guid id, byte[] image)
        {
            var filePath = Path.Combine(imageFolderPath, id + ".jpg");
            File.WriteAllBytes(filePath, image);
        }

        public bool Delete(Guid id)
        {
            var result = false;
            var filePath = Path.Combine(imageFolderPath, id.ToString() + ".jpg");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                result = true;
            }

            return result;
        }
    }
}
