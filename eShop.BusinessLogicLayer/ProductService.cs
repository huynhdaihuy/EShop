using eShopManagement.BusinessLogicLayer.Interfaces;
using eShopManagement.DataAccess.Entities;
using eShopManagement.DataAccessLayer.Interfaces;

namespace eShopManagement.BusinessLogicLayer
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            ValidateProduct(product);
            return await _productRepository.AddProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException("Product id provided invalid!");
            }
            await _productRepository.DeleteProductAsync(id);
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
            var product = _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                Console.WriteLine($"Product with id {id} not found!");
            }
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productRepository.GetProductsAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            ValidateProduct(product);
            await _productRepository.UpdateProductAsync(product);
        }

        // Implementation for business logic
        private static void ValidateProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name) || product.Name.Length > 100)
            {
                throw new ArgumentException("Product name must be between 1 and 100 characters.");
            }

            if (product.Description != null && product.Description.Length > 500)
            {
                throw new ArgumentException("Product description cannot exceed 500 characters.");
            }

            if (product.Price <= 0 || product.Price > 99999.99m)
            {
                throw new ArgumentException("Product price must be greater than 0 and less than 99999.99.");
            }

            if (product.Quantity < 0)
            {
                throw new ArgumentException("Product quantity cannot be negative.");
            }
        }
    }
}
