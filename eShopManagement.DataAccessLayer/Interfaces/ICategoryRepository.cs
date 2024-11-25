using eShopManagement.DataAccess.Entities;

namespace eShopManagement.DataAccessLayer.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();    
        Task<Category> GetCategoryByIdAsync(int id);    
        Task<Category> AddCategoryAsync(Category category);    
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
    }
}
