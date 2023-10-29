using Example.Application.Models.Entities;
using Example.Domain.Models.Entities;

namespace Example.Application.Interfaces
{
    public interface IProductAdditionalFieldService
    {
        Task<Product> Post(int id, List<ProductAdditionalField> request);
    }
}
