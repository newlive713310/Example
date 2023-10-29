using Example.Application.Interfaces;
using Example.Application.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Example.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductAdditionalFieldsController : ControllerBase
    {
        private readonly IProductAdditionalFieldService _productAdditionalFieldService;
        private readonly ILogger<ProductsController> _logger;

        public ProductAdditionalFieldsController(
            IProductAdditionalFieldService productAdditionalFieldService,
            ILogger<ProductsController> logger
            )
        {
            _productAdditionalFieldService = productAdditionalFieldService;
            _logger = logger;
        }
        /// <summary>
        /// Create a list of ProductAdditionalField
        /// </summary>
        /// <param name="id"></param>
        /// <param name="additionalFields"></param>
        /// <returns></returns>
        [HttpPost("{id}/additionalfields")]
        public async Task<IActionResult> Post(int id, List<ProductAdditionalField> request)
        {
            try
            {
                var response = await _productAdditionalFieldService.Post(id, request);

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
