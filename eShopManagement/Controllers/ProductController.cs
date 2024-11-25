using eShopManagement.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using eShopManagement.BusinessLogicLayer.Interfaces;

namespace eShopManagement.PresentationLayer.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var products = await _productService.GetProductsAsync();
                if (products == null) return NotFound();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred.", Details = ex.Message });

            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                if (product == null) return NotFound();
                return Ok(product);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred.", Details = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            try
            {
                var data = await _productService.AddProductAsync(product);
                return Ok(data);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An unexpected error occurred when creation product. {ex}" });
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(Product product)
        {
            try
            {
                await _productService.UpdateProductAsync(product);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An unexpected error occurred when update product. {ex}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An unexpected error occurred when deletion product. {ex}" });
            }
        }
    }
}
