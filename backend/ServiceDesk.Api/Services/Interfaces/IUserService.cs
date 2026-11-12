namespace ServiceDesk.Api.Services.Interfaces;
using ServiceDesk.Api.DTOs.Users;

public interface IUserService{

    Task<List<UserResponseDto>> GetAllUsersAsync();

    Task<List<UserResponseDto>> GetSupportAgentsAsync();




    
}