using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.DTOS;
using E_commerce.Interfaces;
using E_commerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Services
{
    public class UserServices : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;

        public UserServices(UserManager<User> userManager, SignInManager<User> signInManager,
         ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        public async Task<UserDto> CreateUser(RegistrationRequest request)
        {
            var user = new User
            {
                UserName = request.Email,
                Email = request.Email,
                FirstName = request.Firstname,
                LastName = request.Lastname,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.Phone
            };
            var savedUser = await _userManager.CreateAsync(user, request.Password);
            if (savedUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                if (roleResult.Succeeded)
                {
                    var userDto = new UserDto
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        DateOfBirth = user.DateOfBirth
                    };
                    return userDto;
                }
                else
                {
                    await _userManager.DeleteAsync(user);
                    throw new Exception("Failed to add role to user");
                }
            }
            else
            {
                throw new Exception("Failed to create user");
            }
        }

        public async Task<IDictionary<string, string>> LoginUser(LoginDto loginDto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
            if (user == null) throw new Exception("Invalid Email Address");
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) throw new Exception("Invalid Email or Password");
            var token = await _tokenService.CreateToken(user);

            return new Dictionary<string, string>{
                {"Token", token}
            };
        }
    }
}