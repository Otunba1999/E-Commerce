using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.Models;

namespace E_commerce.Interfaces.Repository
{
    public interface ICartRepository
    {
        Task<bool> AddToCart(CartItem cartItem);
        Task<List<CartItem>> GetCartItems(String userId);
        Task<bool> RemoveFromCart(int cartItemId, string userId);
        Task<bool> UpdateCartItem(int cartItemId, int quantity, decimal totalPrice);
        Task<bool> ClearCart(string userId);
    }
}