using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.Models;

namespace E_commerce.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<string> AddProductAsync(Product product);
        Task SaveChangesAsync();
        Task UpdateProductAsync(int id, int quantity);
    }
}