using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using E_commerce.Data;
using E_commerce.Interfaces.Repository;
using E_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.DTOS.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly DataContext _context;
        public CartRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddToCart(CartItem cartItem)
        {
            await _context.CartItems.AddAsync(cartItem);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<bool> ClearCart(string userId)
        {
            var cartItems = _context.CartItems.Where(c => c.UserId == userId).ToList();
            _context.CartItems.RemoveRange(cartItems);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<CartItem>> GetCartItems(string userId)
        {
            return await _context.CartItems.Where(c => c.UserId == userId).ToListAsync();
        }

        public async Task<bool> RemoveFromCart(int cartItemId, string userId)
        {
            var item =  _context.CartItems.FirstOrDefault(c => c.Id == cartItemId && c.UserId == userId);
            if(item != null){
                _context.CartItems.Remove(item);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> UpdateCartItem(int cartItemId, int quantity, decimal totalPrice)
        {
            var item = _context.CartItems.Find(cartItemId);
            if (item != null)
            {
                item.Quantity = quantity;
                item.TotalPrice = totalPrice;
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}