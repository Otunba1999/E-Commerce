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
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly DataContext _context;
        public OrderItemRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(List<OrderItem> orderItems)
        {
            await _context.OrderItems.AddRangeAsync(orderItems);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OrderItem>?> GetOrderItems(int id)
        {
            return await _context.OrderItems.Where(o => o.OrderId == id).ToListAsync();
        }
    }
}