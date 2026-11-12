
using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Api.DTOs.Users;
using ServiceDesk.Api.Models;
using ServiceDesk.Api.Services.Interfaces;

namespace ServiceDesk.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController (IUserService userService)
    {
        _userService = userService;
        
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllUsersAsync();

        return Ok(users);
    }
    [HttpGet("support-agents")]
    public async Task<IActionResult> GetSupportAgents()
    {
        var supportAgents= await _userService.GetSupportAgentsAsync();
        return Ok(supportAgents);
    }
}
