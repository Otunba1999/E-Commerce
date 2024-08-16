using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace E_commerce.Models
{
    public class User : IdentityUser
    {

        [Required]
        public string? FirstName { get; set; }
        [Required]
        public  string? LastName { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

    }
}