using Example.Application.Interfaces;
using Example.Domain.Models;
using Example.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Example.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<ProductService> _logger;

        public ProductService(
            ApplicationContext context,
            ILogger<ProductService> logger
            )
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Product> Delete(int id)
        {
            _logger.LogDebug($"Calling the {nameof(Delete)} method");

            try
            {
                var response = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

                if (response == null )
                    return null;

                _context.Products.Remove(response);

                await _context.SaveChangesAsync();

                return await Task.FromResult(response);
            }
            catch
            {
                _logger.LogDebug($"Failed to call method {nameof(Delete)}");
                throw;
            }
            finally { }
        }

        public async Task<IEnumerable<Product>> Get()
        {
            _logger.LogDebug($"Calling the {nameof(Get)} method");

            try
            {
                var response = await _context.Products
                .Include(p => p.ProductAdditionalFields)
                .ToListAsync();

                return await Task.FromResult(response);
            }
            catch 
            {
                _logger.LogDebug($"Failed to call method {nameof(Get)}");
                throw;
            }
            finally { }
        }

        public async Task<Product> GetById(int id)
        {
            _logger.LogDebug($"Calling the {nameof(GetById)} method");

            try
            {
                var response = await _context.Products
                .Include(p => p.ProductAdditionalFields)
                .FirstOrDefaultAsync(p => p.Id == id);

                return await Task.FromResult(response);
            }
            catch
            {
                _logger.LogDebug($"Failed to call method {nameof(Get)}");
                throw;
            }
            finally { }
        }

        public async Task Post(Product request)
        {
            _logger.LogDebug($"Calling the {nameof(Post)} method");

            try
            {
                _context.Products.Add(request);

                await _context.SaveChangesAsync();
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
