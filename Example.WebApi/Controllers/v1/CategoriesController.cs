using Example.Application.Interfaces;
using Example.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Example.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(
            ICategoryService categoryService,
            ILogger<CategoriesController> logger
            )
        {
            _categoryService = categoryService;
            _logger = logger;
        }
        /// <summary>
        /// Get a list of categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            try
            {
                var response = await _categoryService.Get();

                return Ok(await Task.FromResult(response));
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"Error occured in {nameof(Get)}. Message: {ex.Message}");

                return BadRequest(ex.Message);
            }
            finally { }
        }
        /// <summary>
        /// Get a category by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            try
            {
                var response = await _categoryService.GetById(id);

                if (response == null)
                    return NotFound();

                return Ok(await Task.FromResult(response));
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"Error occured in {nameof(Get)}. Message: {ex.Message}");

                return BadRequest(ex.Message);
            }
            finally { }
        }
        /// <summary>
        /// Post a category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Product>> Post(Category category)
        {
            try
            {
                await _categoryService.Post(category);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"Error occured in {nameof(Post)}. Message: {ex.Message}");

                return BadRequest(ex.Message);
            }
            finally { }
        }
        /// <summary>
        /// Delete a category by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _categoryService.Delete(id);

                if (response == null)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"Error occured in {nameof(Get)}. Message: {ex.Message}");

                return BadRequest(ex.Message);
            }
            finally { }
        }
    }
}
