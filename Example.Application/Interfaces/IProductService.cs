using Example.Domain.Models.Entities;

namespace Example.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> Get();
        Task<Product> GetById(int id);
        Task Post(Product request);
        Task<Product> Delete(int id);
    }
}