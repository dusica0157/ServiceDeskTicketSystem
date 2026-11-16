namespace ServiceDesk.Api.Services.Interfaces;
using ServiceDesk.Api.DTOs.Users;
using ServiceDesk.Api.DTOs.Auth;


public interface IAuthService
{
    
     Task<UserResponseDto?> RegisterAsync(RegisterDto dto);
     Task<UserResponseDto?> LoginAsync(LoginDto dto);
}