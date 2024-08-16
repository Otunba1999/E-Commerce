using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.Models;

namespace E_commerce.DTOS
{
    public class OrderDto
    {
        public int Id { get; set; }
        
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public List<ItemDto>? OrderItems { get; set; }

    }
}