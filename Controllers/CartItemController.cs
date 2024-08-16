using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.Interfaces.Services;
using E_commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace E_commerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartItemController : ControllerBase
    {
        private readonly ICartService _cartItemService;

        public CartItemController(ICartService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToCart([FromBody] CartItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;
            if (userId != null)
            {
                var response = await _cartItemService.AddToCart(item, userId);
                return Ok(response);
            }
            return Unauthorized();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCartItems()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;
            if (userId != null)
            {
                var response = await _cartItemService.GetCartItems(userId);
                return Ok(response);
            }
            return Unauthorized();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;
            if (userId != null)
            {
                var response = await _cartItemService.RemoveFromCart(id, userId);
                return Ok(response);
            }
            return Unauthorized();
        }
    }
}