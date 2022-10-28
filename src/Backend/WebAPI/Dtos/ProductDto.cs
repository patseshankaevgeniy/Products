using System;

namespace WebAPI.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ImageId { get; set; }
    }
}
