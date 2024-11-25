﻿using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
