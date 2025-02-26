using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.DTOS
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public required decimal Price { get; set; }
        [Required]
        public required int Quantity { get; set; }

    }
}