using Example.Domain.Models.Entities;

namespace Example.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> Get();
        Task<Category> GetById(int id);
        Task Post(Category request);
        Task<Category> Delete(int id);
    }
}
