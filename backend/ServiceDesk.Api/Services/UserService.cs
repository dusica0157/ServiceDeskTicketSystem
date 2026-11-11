namespace ServiceDesk.Api.Services;

using ServiceDesk.Api.Data;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Api.Services.Interfaces;
using ServiceDesk.Api.DTOs.Users;

public class UserService : IUserService
{

    private readonly AppDbContext _db;

    public UserService(AppDbContext db)
    {
        _db = db;
    }

    public async  Task<List<UserResponseDto>> GetAllUsersAsync()
    {
        return await _db.Users.Select(user => new UserResponseDto
        {
            Id= user.Id,
            FirstName= user.FirstName,
             LastName= user.LastName,
             Email=user.Email,
             Role=user.Role,



            
        }).ToListAsync();
    }





}