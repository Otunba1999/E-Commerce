using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.DTOS
{
    public class RegistrationRequest
    {
        [Required]
        public string? Firstname { get; set; }
        [Required]
        public string? Lastname { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public DateTime? DateOfBirth {get; set;}
        public string? Phone { get; set; }
        
    }
}