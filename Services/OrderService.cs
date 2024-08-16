using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.DTOS;
using E_commerce.Interfaces.Repository;
using E_commerce.Interfaces.Services;
using E_commerce.Models;
using Microsoft.IdentityModel.Tokens;

namespace E_commerce.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IProductRepository _productRepository;
        public OrderService(IOrderRepository orderRepository, ICartRepository cartRepository,
        IOrderItemRepository orderItemRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
        }

        public async Task<string> CreateOrder(string userId)
        {
            var items = await _cartRepository.GetCartItems(userId);
            if (items.IsNullOrEmpty())
                return "Cart is Empty Add Item to cart";
            var orderItems = new List<OrderItem>();
            decimal totalPrice = 0;
            foreach (var item in items)
            {
                var product = await _productRepository.GetProductByIdAsync(item.ProductId);
                if (product.Quantity < item.Quantity)
                    return $"{product.Name} Out of Stock, unable to create order; Quantity available {product.Quantity}, item quantity ordered {item.Quantity}";

                product.Quantity -= item.Quantity;
                await _productRepository.UpdateProductAsync(product.Id, product.Quantity);
                totalPrice += item.TotalPrice;
            }
            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                TotalAmount = totalPrice,
            };
            var savedOrder = await _orderRepository.CreateOrder(order);
            if (savedOrder != null)
            {
                foreach (var item in items)
                {
                    orderItems.Add(new OrderItem
                    {
                        OrderId = savedOrder.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.TotalPrice / item.Quantity,
                        ProductName = item.ProductName
                    });
                }
                await _orderItemRepository.CreateAsync(orderItems);
                await _cartRepository.ClearCart(userId);
                // await _orderRepository.UpdateOrder(savedOrder.Id, orderItems);
                return "Order Created Successfully";
            }
            return "Order Creation Failed";
        }



        public async Task<List<OrderDto>> GetOrders(string userId)
        {
            var orders = await _orderRepository.GetAllOrders(userId);
            var orderDtos = new List<OrderDto>();
            foreach (var order in orders)
            {
                List<OrderItem>? orderItems = await _orderItemRepository.GetOrderItems(order.Id);
                var items = orderItems?.Select(oi =>
                {
                    return new ItemDto
                    {
                        Quantity = oi.Quantity,
                        UnitPrice = oi.UnitPrice,
                        ProductName = oi.ProductName,
                        TotalPrice = oi.UnitPrice * oi.Quantity
                    };
                }).ToList();
                orderDtos.Add(new OrderDto
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    TotalAmount = order.TotalAmount,
                    OrderItems = items
                });

            }
            return orderDtos;

        }
    }
}