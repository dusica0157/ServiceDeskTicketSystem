using ServiceDesk.Api.Models;

namespace ServiceDesk.Api.Services.Interfaces;


public interface ITicketService
{
  Task<List<Ticket>> GetAllTicketsAsync();
}