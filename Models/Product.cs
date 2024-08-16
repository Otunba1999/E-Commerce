using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public required decimal Price { get; set; }
        public required int Quantity { get; set; }
        public List<OrderItem>? OrderItems {get; set;}
    }
}