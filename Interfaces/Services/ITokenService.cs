using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.Models;

namespace E_commerce.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
        DateTime? GetTokenExpDate(string token);
    }
}