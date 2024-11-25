using eShopManagement.BusinessLogicLayer.Interfaces;
using eShopManagement.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eShopManagement.PresentationLayer.Controllers
{
    [ApiController]
    [Route("category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var categories = await _categoryService.GetCategoriesAsync();
                if (categories == null) return NotFound();
                return Ok(categories);
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
                var category = await _categoryService.GetCategoryByIdAsync(id);
                if (category == null) return NotFound();
                return Ok(category);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred.", Details = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Category category)
        {
            try
            {
                var data = await _categoryService.AddCategoryAsync(category);
                return Ok(data);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An unexpected error occurred when creation product. {ex}" });
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(Category category)
        {
            try
            {
                await _categoryService.UpdateCategoryAsync(category);
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
                await _categoryService.DeleteCategoryAsync(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An unexpected error occurred when deletion product. {ex}" });
            }
        }
    }
}
