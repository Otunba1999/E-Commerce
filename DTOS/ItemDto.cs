using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.DTOS
{
    public class ItemDto
    {
        public string? ProductName { get; set; }
        public int Quantity {get; set;}
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}