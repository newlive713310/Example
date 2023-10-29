using Example.Application.Interfaces;
using Example.Application.Models.Entities;
using Example.Domain.Models;
using Example.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Example.Application.Services
{
    public class ProductAdditionalFieldService : IProductAdditionalFieldService
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<ProductService> _logger;

        public ProductAdditionalFieldService(
            ApplicationContext context,
            ILogger<ProductService> logger
            )
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Product> Post(int id, List<ProductAdditionalField> request)
        {
            _logger.LogDebug($"Calling the {nameof(Post)} method");

            try
            {
                var response = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

                if (response == null)
                    return null;

                foreach (var field in request)
                {
                    field.ProductId = id;
                    _context.ProductAdditionalFields.Add(field);
                }

                await _context.SaveChangesAsync();

                return await Task.FromResult(response);
            }
            catch
            {
                _logger.LogDebug($"Failed to call method {nameof(Post)}");
                throw;
            }
            finally { }
        }
    }
}