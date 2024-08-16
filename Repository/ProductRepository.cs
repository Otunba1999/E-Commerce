using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.Data;
using E_commerce.Interfaces.Repository;
using E_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.DTOS.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext   _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<string> AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return "Product uploaded";
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id) ?? null;
        }

        public async Task SaveChangesAsync() 
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(int id, int quantity)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            product.Quantity = quantity;
            await _context.SaveChangesAsync();
        }
    }
}