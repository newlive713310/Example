using Example.Application.Interfaces;
using Example.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Example.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(
            IProductService productService,
            ILogger<ProductsController> logger
            )
        {
            _productService = productService;
            _logger = logger;
        }
        /// <summary>
        /// Get a list of products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _productService.Get();

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
        /// Get a product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            try
            {
                var response = await _productService.GetById(id);

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
        /// Create a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            try
            {
                await _productService.Post(product);

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
        /// Delete a product by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _productService.Delete(id);

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
