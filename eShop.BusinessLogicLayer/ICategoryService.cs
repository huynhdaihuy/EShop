using eShopManagement.DataAccess.Entities;

namespace eShopManagement.BusinessLogicLayer.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> AddCategoryAsync(Category product);
        Task UpdateCategoryAsync(Category product);
        Task DeleteCategoryAsync(int id);
    }
}
