using eShopManagement.DataAccess.Entities;

namespace eShopManagement.DataAccessLayer.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();    
        Task<Product> GetProductByIdAsync(int id);    
        Task<Product> AddProductAsync(Product product);    
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
