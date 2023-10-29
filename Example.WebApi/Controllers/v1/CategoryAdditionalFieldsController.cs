using Example.Application.Interfaces;
using Example.Application.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Example.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CategoryAdditionalFieldsController : ControllerBase
    {
        private readonly ICategoryAdditionalFieldService _categoryAdditionalFieldService;
        private readonly ILogger<CategoryAdditionalFieldsController> _logger;

        public CategoryAdditionalFieldsController(
            ICategoryAdditionalFieldService categoryAdditionalFieldService,
            ILogger<CategoryAdditionalFieldsController> logger
            )
        {
            _categoryAdditionalFieldService = categoryAdditionalFieldService;
            _logger = logger;
        }
        /// <summary>
        /// Get a list of CategoryAdditionalFields
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _categoryAdditionalFieldService.Get();

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
        /// Create a list of CategoryAdditionalFields
        /// </summary>
        /// <param name="id"></param>
        /// <param name="additionalFields"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(int id, List<CategoryAdditionalField> request)
        {
            try
            {
                var response = await _categoryAdditionalFieldService.Post(id, request);

                if (response == null)
                    return NotFound();

                return Ok(await Task.FromResult(response));
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"Error occured in {nameof(Post)}. Message: {ex.Message}");

                return BadRequest(ex.Message);
            }
            finally { }
        }
    }
}
