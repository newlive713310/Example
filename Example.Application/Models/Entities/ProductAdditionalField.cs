using Example.Domain.Models.Entities;

namespace Example.Application.Models.Entities
{
    public class ProductAdditionalField
    {
        public int Id { get; set; }
        public int CategoryAdditionalFieldId { get; set; }
        public int ProductId { get; set; }
        public string FieldValue { get; set; }
    }
}
