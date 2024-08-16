using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.Interfaces.Repository;
using E_commerce.Interfaces.Services;
using E_commerce.Models;

namespace E_commerce.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        public CartService(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }
        public async Task<string> AddToCart(CartItem cartItem, string userId)
        {
            if (cartItem.Quantity <= 0)
                return "Quantity must be greater than 0";

            var items = await _cartRepository.GetCartItems(userId);

            var product = await _productRepository.GetProductByIdAsync(cartItem.ProductId);
            if (product == null)
                return "Product not found";

            if (items.Any(i => i.ProductId == cartItem.ProductId))
            {
                var item = items.FirstOrDefault(i => i.ProductId == cartItem.ProductId);
                item.Quantity += cartItem.Quantity;
                if (product.Quantity < item.Quantity)
                    return "Not enough stock";
                item.TotalPrice = product.Price * item.Quantity;
                await _cartRepository.UpdateCartItem(item.Id, item.Quantity, item.TotalPrice);
                return "Product quantity updated";
            }


            if (product.Quantity < cartItem.Quantity)
                return "Not enough stock";

            cartItem.UserId = userId;
            cartItem.TotalPrice = product.Price * cartItem.Quantity;
            cartItem.ProductName = product.Name;
            var result = await _cartRepository.AddToCart(cartItem);
            if (!result)
                return "Error adding to cart";

            return "Product added to cart";

        }

        public void ClearCart(string userId)
        {
            _cartRepository.ClearCart(userId);
        }

        public Task<List<CartItem>> GetCartItems(string userId)
        {
            return _cartRepository.GetCartItems(userId);
        }

        public async Task<string> RemoveFromCart(int cartItemId, string userId)
        {
            var result = await _cartRepository.RemoveFromCart(cartItemId, userId);
            if (result)
                return "Product removed from cart";
            return "Unable to remove product";
        }
    }
}