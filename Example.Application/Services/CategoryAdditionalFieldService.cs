using Example.Application.Interfaces;
using Example.Application.Models.Entities;
using Example.Domain.Models;
using Example.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Example.Application.Services
{
    public class CategoryAdditionalFieldService : ICategoryAdditionalFieldService
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<CategoryAdditionalFieldService> _logger;

        public CategoryAdditionalFieldService(
            ApplicationContext context,
            ILogger<CategoryAdditionalFieldService> logger
            )
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<CategoryAdditionalField>> Get()
        {
            _logger.LogDebug($"Calling the {nameof(Get)} method");

            try
            {
                var response = await _context.CategoryAdditionalFields.ToListAsync();

                return await Task.FromResult(response);
            }
            catch
            {
                _logger.LogDebug($"Failed to call method {nameof(Get)}");
                throw;
            }
            finally { }
        }

        public async Task<Category> Post(int id, List<CategoryAdditionalField> request)
        {
            _logger.LogDebug($"Calling the {nameof(Post)} method");

            try
            {
                var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

                if (category == null)
                    return null;

                foreach (var field in request)
                    _context.CategoryAdditionalFields.Add(field);

                await _context.SaveChangesAsync();

                return category;
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
