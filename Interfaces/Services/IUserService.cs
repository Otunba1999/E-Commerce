using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.DTOS;

namespace E_commerce.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateUser(RegistrationRequest request);
        Task<IDictionary<string, string>> LoginUser(LoginDto loginDto);
    }
}