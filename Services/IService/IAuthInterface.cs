using BookshopApi.Models;
using BookshopApi.Models.Dto;

namespace BookshopApi.Services.IService
{
    public interface IAuthInterface
    {
        Task<User> RegisterUserAsync(UserDto request);

        Task<TokenResponseDto> LoginAsync(UserDto request);
    }
}
