namespace ServiceDesk.Api.Services;

using ServiceDesk.Api.Services.Interfaces;
using ServiceDesk.Api.Data;
using ServiceDesk.Api.Models;
using ServiceDesk.Api.DTOs.Users;
using ServiceDesk.Api.DTOs.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
public class AuthService : IAuthService
{
    private readonly AppDbContext _db;
    private readonly PasswordHasher<User> _passwordHasher = new();

    public AuthService(AppDbContext db)
    {
        _db = db;
    }
    public async Task<UserResponseDto?> RegisterAsync(RegisterDto dto)
    {
        var emailExists = await _db.Users.AnyAsync(user => user.Email == dto.Email);

        if (emailExists == true)
        {
            return null;
        }

        var user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Role = UserRole.Employee,

        };

        user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        return new UserResponseDto
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Role = UserRole.Employee,

        };

    }
}
