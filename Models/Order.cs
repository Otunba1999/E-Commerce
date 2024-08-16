using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public List<OrderItem>? OrderItems { get; set; }

    }
}