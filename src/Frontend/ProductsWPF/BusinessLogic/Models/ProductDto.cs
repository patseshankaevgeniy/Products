using System;

namespace BusinessLogic.Models
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ImageId { get; set; }
    }
}
