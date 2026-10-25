using ServiceDesk.Api.DTOs.Tickets;

namespace ServiceDesk.Api.Services.Interfaces;

public interface ITicketService
{
    Task<List<TicketResponseDto>> GetAllTicketsAsync();

    Task<TicketResponseDto> CreateTicketAsync(
        CreateTicketDto dto,
        int createdByUserId);
}