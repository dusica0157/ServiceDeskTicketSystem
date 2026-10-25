using ServiceDesk.Api.Enums;

namespace ServiceDesk.Api.DTOs.Tickets;

public class TicketResponseDto
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public TicketStatus Status { get; set; }

    public TicketPriority Priority { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedByUserId { get; set; }

    public int CategoryId { get; set; }

    public int? AssignedAgentId { get; set; }
}