using Microsoft.EntityFrameworkCore;
using ServiceDesk.Api.Data;
using ServiceDesk.Api.Models;
using ServiceDesk.Api.Services.Interfaces;

namespace ServiceDesk.Api.Services;


public class TicketService : ITicketService
{

    private readonly AppDbContext _db;
    
    public TicketService(AppDbContext db)
    {
        _db=db;
    }

    public async Task<List<Ticket>> GetAllTicketsAsync()
    {
        return await _db.Tickets.ToListAsync();
    }
    
}