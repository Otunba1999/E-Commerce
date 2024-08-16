using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.Models;

namespace E_commerce.Interfaces.Services
{
    public interface ICartService
    {
        Task<string> AddToCart(CartItem cartItem, string userId);
        Task<string> RemoveFromCart(int cartItemId, string userId);
        void ClearCart(string cartId);
        Task<List<CartItem>> GetCartItems(string userId);
    }
}