using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.Models;

namespace E_commerce.Interfaces.Repository
{
    public interface IOrderItemRepository
    {
        Task CreateAsync(List<OrderItem> orderItems);
        Task<List<OrderItem>?> GetOrderItems(int id);
    }
}