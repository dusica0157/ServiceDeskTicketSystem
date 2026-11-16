namespace ServiceDesk.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Api.Services.Interfaces;

using ServiceDesk.Api.DTOs.Auth;


[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var response = await _authService.RegisterAsync(dto);

        if (response == null)
        {
            return Conflict();
        }

        return Ok(response);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var result = await _authService.LoginAsync(dto);

        if (result == null)
        {
            return Unauthorized();
        }

        return Ok(result);
    }

}