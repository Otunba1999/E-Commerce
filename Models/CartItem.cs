using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
    }
}