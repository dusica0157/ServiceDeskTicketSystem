namespace ServiceDesk.Api.Services;

using Microsoft.EntityFrameworkCore;
using ServiceDesk.Api.Services.Interfaces;
using ServiceDesk.Api.Data;
using ServiceDesk.Api.Models;
using ServiceDesk.Api.DTOs.Comments;
public class CommentService : ICommentService
{
    private readonly AppDbContext _db;

    public CommentService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<CommentResponseDto>> GetCommentsByTicketIdAsync(int ticketId)
    {
        return await _db.Comments.Where(comment => comment.TicketId == ticketId).Select(comment => new CommentResponseDto
        {
            Id = comment.Id,
            Content = comment.Content,
            UserId = comment.UserId,
            CreatedAt = comment.CreatedAt
        }).ToListAsync();

    }
    public async Task<CommentResponseDto?> CreateCommentAsync(int ticketId, CreateCommentDto dto)
    {
        var ticket = await _db.Tickets.FirstOrDefaultAsync(ticket => ticket.Id == ticketId);

        if (ticket == null)
        {
            return null;
        }

        var comment = new Comment
        {
            Content = dto.Content,
            TicketId = ticketId,
            UserId = dto.UserId


        };


        await _db.Comments.AddAsync(comment);

        await _db.SaveChangesAsync();

        return new CommentResponseDto
        {
            Id = comment.Id,
            Content = comment.Content,
            UserId = comment.UserId,
            CreatedAt = comment.CreatedAt

        };

    }
}