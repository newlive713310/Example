using Example.Application.Interfaces;
using Example.Domain.Models;
using Example.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Example.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<ProductService> _logger;

        public CategoryService(
            ApplicationContext context,
            ILogger<ProductService> logger
            )
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Category> Delete(int id)
        {
            _logger.LogDebug($"Calling the {nameof(Delete)} method");

            try
            {
                var response = await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);

                if (response == null)
                    return null;

                _context.Categories.Remove(response);

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

        public async Task<IEnumerable<Category>> Get()
        {
            _logger.LogDebug($"Calling the {nameof(Get)} method");

            try
            {
                var response = await _context.Categories
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

        public async Task<Category> GetById(int id)
        {
            _logger.LogDebug($"Calling the {nameof(GetById)} method");

            try
            {
                var response = await _context.Categories.FindAsync(id);

                return await Task.FromResult(response);
            }
            catch
            {
                _logger.LogDebug($"Failed to call method {nameof(Get)}");
                throw;
            }
            finally { }
        }

        public async Task Post(Category request)
        {
            _logger.LogDebug($"Calling the {nameof(Post)} method");

            try
            {
                _context.Categories.Add(request);

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
