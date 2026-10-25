using ServiceDesk.Api.DTOs.Tickets;
using ServiceDesk.Api.Models;


namespace ServiceDesk.Api.Services.Interfaces;


public interface ITicketService
{
  Task<List<Ticket>> GetAllTicketsAsync();

  Task<Ticket> CreateTicketAsync(CreateTicketDto dto, int createdByUserId);
}