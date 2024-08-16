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
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Order> CreateOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<List<Order>> GetAllOrders(string userId)
        {
            var result = await _context.Orders.Where(o => o.UserId == userId).ToListAsync();
            return result;
        }

        public async Task UpdateOrder(int id, List<OrderItem> orderItems)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(p => p.Id == id);
            order.OrderItems = orderItems;
            await _context.SaveChangesAsync();

        }
    }
}