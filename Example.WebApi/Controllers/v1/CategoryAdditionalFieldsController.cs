using Example.Application.Models.Entities;
using Example.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Example.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CategoryAdditionalFieldsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CategoryAdditionalFieldsController(ApplicationContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get a list of CategoryAdditionalFields
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categoryAdditionalFields = await _context.CategoryAdditionalFields.ToListAsync();

            return Ok(categoryAdditionalFields);
        }
        /// <summary>
        /// Create a list of CategoryAdditionalFields
        /// </summary>
        /// <param name="id"></param>
        /// <param name="additionalFields"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(int id, List<CategoryAdditionalField> additionalFields)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            foreach (var field in additionalFields)
            {
                if (field.CategoryId != id)
                {
                    return BadRequest("Category ID mismatch in additional fields.");
                }

                _context.CategoryAdditionalFields.Add(field);
            }

            await _context.SaveChangesAsync();

            return StatusCode(201, additionalFields);
        }
    }
}
