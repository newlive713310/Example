using Example.Application.Models.Entities;

namespace Example.Domain.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public ICollection<ProductAdditionalField>? ProductAdditionalFields { get; set; }
    }
}
