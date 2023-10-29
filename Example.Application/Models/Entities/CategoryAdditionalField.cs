using Example.Domain.Models.Entities;

namespace Example.Application.Models.Entities
{
    public class CategoryAdditionalField
    {
        public int Id { get; set; }
        public string FieldName { get; set; }
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
