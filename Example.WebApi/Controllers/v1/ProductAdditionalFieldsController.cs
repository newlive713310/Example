using Example.Application.Models.Entities;
using Example.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Example.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductAdditionalFieldsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ProductAdditionalFieldsController(ApplicationContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Create a list of ProductAdditionalField
        /// </summary>
        /// <param name="id"></param>
        /// <param name="additionalFields"></param>
        /// <returns></returns>
        [HttpPost("{id}/additionalfields")]
        public async Task<IActionResult> Post(int id, List<ProductAdditionalField> additionalFields)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            foreach (var field in additionalFields)
            {
                field.ProductId = id;
                _context.ProductAdditionalFields.Add(field);
            }

            await _context.SaveChangesAsync();

            return StatusCode(201, additionalFields);
        }
    }
}
