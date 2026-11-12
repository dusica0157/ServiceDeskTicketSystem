
namespace ServiceDesk.Api.DTOs.Comments;

public class CreateCommentDto
{

    public string Content { get; set; } = string.Empty;
    public int UserId { get; set; }
}