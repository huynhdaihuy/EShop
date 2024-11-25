using eShopManagement.BusinessLogicLayer.Interfaces;
using eShopManagement.DataAccess.Entities;
using eShopManagement.DataAccessLayer.Interfaces;
using Microsoft.Extensions.Logging;

namespace eShopManagement.BusinessLogicLayer
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository categoryRepository, ILogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }
        public async Task<Category> AddCategoryAsync(Category category)
        {
            ValidateCategory(category);
            return await _categoryRepository.AddCategoryAsync(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            if(id <= 0)
            {
                _logger.LogWarning($"Category with id {id} is invalid!");
                throw new ArgumentException("Category id provided invalid!");
            }
            await _categoryRepository.DeleteCategoryAsync(id);
        }

        public Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                _logger.LogWarning($"Category with id {id} not found!");
            }
            return category!;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetCategoriesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            ValidateCategory(category);
            await _categoryRepository.UpdateCategoryAsync(category);
        }

        // Implementation for business logic
        private static void ValidateCategory(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name) || category.Name.Length > 100)
            {
                throw new ArgumentException("Category's name must be between 1 and 100 characters.");
            }
        }
    }
}
