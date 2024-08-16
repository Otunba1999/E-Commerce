using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.Models;

namespace E_commerce.Interfaces.Repository
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrder(Order order);
        Task<List<Order>> GetAllOrders(string userId);
        Task UpdateOrder(int id, List<OrderItem> orderItems);
    }
}