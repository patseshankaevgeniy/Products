using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DataAccess.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly string productsFilePath;
        private readonly IImagesRepository _imagesRepository;

        public ProductsRepository(IConfiguration configuration, IImagesRepository
            imagesRepository)
        {
            productsFilePath = Path.Combine(Directory.GetCurrentDirectory(), configuration["ProductsFilePath"]);
            _imagesRepository = imagesRepository;
        }

        public List<ProductEntity> GetAll()
        {
            return ReadFromFile();
        }

        public ProductEntity Create(ProductEntity product)
        {
            var products = ReadFromFile();

            product.Id = Guid.NewGuid();
            //_imagesRepository.Create()
            products.Add(product);

            SaveIntoFile(products);

            return product;
        }

        public ProductEntity Update(Guid id, ProductEntity product)
        {
            var products = ReadFromFile();

            foreach (var item in products)
            {
                if (item.Id == id)
                {
                    item.Name = product.Name;
                    item.ImageName = product.ImageName;
                    break;
                }
            }

            SaveIntoFile(products);

            return product;
        }

        public bool Delete(Guid id)
        {
            var result = false;
            var products = ReadFromFile();

            foreach (var product in products)
            {
                if (product.Id == id)
                {
                    products.Remove(product);
                    result = true;
                    break;
                }
            }

            SaveIntoFile(products);

            return result;
        }

        private List<ProductEntity> ReadFromFile()
        {
            using var fileStream = File.OpenRead(productsFilePath);
            return JsonSerializer.Deserialize<List<ProductEntity>>(fileStream);
        }

        private void SaveIntoFile(List<ProductEntity> products)
        {
            var p = JsonSerializer.Serialize(products);
            File.WriteAllText(productsFilePath, p);
        }
    }
}
