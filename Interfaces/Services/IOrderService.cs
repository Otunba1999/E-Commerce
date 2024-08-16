using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.DTOS;
using E_commerce.Models;

namespace E_commerce.Interfaces.Services
{
    public interface IOrderService
    {
        Task<string> CreateOrder(string userId);
        Task<List<OrderDto>> GetOrders(string userId);
    }
}