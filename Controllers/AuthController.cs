using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookshopApi.Models;
using BookshopApi.Models.Dto;
using BookshopApi.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace BookshopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthInterface _authService;
       

        public AuthController(IAuthInterface authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var user = await _authService.RegisterUserAsync(request);

            if (user is null)
                return BadRequest("Username already exists!!");

            return Ok(user);
        }

        [HttpPost("login")]

        public async Task<ActionResult<TokenResponseDto>> Login(UserDto request)
        {
            var result = await _authService.LoginAsync(request);

            if (result is null)
                return BadRequest("Invalid username or password!!");

            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDto request)
        {
            var result = await _authService.RefreshTokenAsync(request);
            if (result is null || result.AccessToken is null || result.RefreshToken is null)
                return Unauthorized("Invalid refresh Token.");

            return Ok(result);
        }
        //protected route
        [Authorize]
        [HttpGet]

        public IActionResult AuthenticatedOnlyEndpoint()
        {
            return Ok("You are authenticated!");
        }

        //admin route

        [Authorize(Roles = "Admin")]
        [HttpGet("admins-only")]

        public IActionResult AdminsOnlyEndpoint()
        {
            return Ok("You are authenticated as admin!");
        }



    }
}
