using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.DTOS;
using E_commerce.DTOS.Mappers;
using E_commerce.Interfaces;
using E_commerce.Interfaces.Repository;

namespace E_commerce.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<string> AddProduct(ProductDTO productDTO)
        {
           var product = productDTO.ToProduct();//ProductMapper.ToProduct(productDTO);
           return _productRepository.AddProductAsync(product);
        }

        public async Task<List<ProductDTO>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return products.Select(p => p.ToProductDTO()).ToList();
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return product.ToProductDTO();
        }
    }
}