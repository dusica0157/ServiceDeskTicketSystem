namespace ServiceDesk.Api.DTOs.Users;

using ServiceDesk.Api.Models;

public class UserResponseDto
{
      public int Id { get; set; }
      public string FirstName { get; set; } = string.Empty;
      public string LastName { get; set; } = string.Empty;
      public string Email { get; set; } = string.Empty;
      public UserRole Role { get; set; } = UserRole.Employee;
}