using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.DTOS;

namespace E_commerce.Interfaces
{
    public interface IProductService
    {
        Task<string> AddProduct(ProductDTO productDTO);
        Task<List<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetProductById(int id);
    }
}