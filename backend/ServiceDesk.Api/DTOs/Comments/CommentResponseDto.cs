
namespace ServiceDesk.Api.DTOs.Comments;



public class CommentResponseDto
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;

    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }


}