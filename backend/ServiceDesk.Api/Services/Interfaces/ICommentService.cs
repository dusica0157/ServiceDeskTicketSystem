namespace ServiceDesk.Api.Services.Interfaces;
using ServiceDesk.Api.DTOs.Comments;
public interface ICommentService
{
    Task<List<CommentResponseDto>> GetCommentsByTicketIdAsync(int ticketId);
    Task<CommentResponseDto?> CreateCommentAsync(int ticketId, CreateCommentDto dto);
}