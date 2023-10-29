using Example.Application.Models.Entities;
using Example.Domain.Models.Entities;

namespace Example.Application.Interfaces
{
    public interface ICategoryAdditionalFieldService
    {
        Task<IEnumerable<CategoryAdditionalField>> Get();
        Task<Category> Post(int id, List<CategoryAdditionalField> request);
    }
}
