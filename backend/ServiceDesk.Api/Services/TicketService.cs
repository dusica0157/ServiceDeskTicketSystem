using Microsoft.EntityFrameworkCore;
using ServiceDesk.Api.Data;
using ServiceDesk.Api.DTOs.Tickets;
using ServiceDesk.Api.Models;
using ServiceDesk.Api.Services.Interfaces;

namespace ServiceDesk.Api.Services;


public class TicketService : ITicketService
{

    private readonly AppDbContext _db;

    public TicketService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<TicketResponseDto>> GetAllTicketsAsync()
    {
         return await _db.Tickets
        .Select(ticket => new TicketResponseDto
        {
            Id = ticket.Id,
            Title = ticket.Title,
            Description = ticket.Description,
            Status = ticket.Status,
            Priority = ticket.Priority,
            CreatedAt = ticket.CreatedAt,
            CreatedByUserId = ticket.CreatedByUserId,
            CategoryId = ticket.CategoryId,
            AssignedAgentId = ticket.AssignedAgentId
        })
        .ToListAsync();
    }

    public async Task<TicketResponseDto> CreateTicketAsync(CreateTicketDto dto, int createdByUserId)

    {

        bool categoryExists = await _db.Categories
    .AnyAsync(category => category.Id == dto.CategoryId);

        if (!categoryExists)
        {
            throw new ArgumentException("Category does not exist.");
        }

        bool userExists = await _db.Users
    .AnyAsync(user => user.Id == createdByUserId);

        if (!userExists)
        {
            throw new ArgumentException("User does not exist.");
        }
        var ticket = new Ticket
        {
            Title = dto.Title,
            Description = dto.Description,
            CategoryId = dto.CategoryId,
            CreatedByUserId = createdByUserId

        };

        _db.Tickets.Add(ticket);

        await _db.SaveChangesAsync();
        return new TicketResponseDto
        {
            Id = ticket.Id,
            Title = ticket.Title,
            Description = ticket.Description,
            Status = ticket.Status,
            Priority = ticket.Priority,
            CreatedAt = ticket.CreatedAt,
            CreatedByUserId = ticket.CreatedByUserId,
            CategoryId = ticket.CategoryId,
            AssignedAgentId = ticket.AssignedAgentId
        };
    }


}