using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Api.DTOs.Tickets;
using ServiceDesk.Api.Models;
using ServiceDesk.Api.Services.Interfaces;

namespace ServiceDesk.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketsController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tickets = await _ticketService.GetAllTicketsAsync();

        return Ok(tickets);
    }
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateTicketDto dto,
        [FromQuery] int createdByUserId)
    {
        try
        {
            var ticket = await _ticketService.CreateTicketAsync(dto, createdByUserId);
            return StatusCode(201, ticket);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }

    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var ticket = await _ticketService.GetTicketByIdAsync(id);

        if (ticket == null)
        {
            return NotFound();

        }
        return Ok(ticket);
    }
    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateStatus(
     [FromRoute] int id,
     [FromBody] UpdateTicketStatusDto dto)
    {
        try
        {
            var updatedTicket = await _ticketService
                .UpdateTicketStatusAsync(id, dto);

            if (updatedTicket == null)
            {
                return NotFound();
            }

            return Ok(updatedTicket);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
     [HttpPatch("{id}/assign")]
    public async Task<IActionResult> UpdateAgent(
        [FromRoute] int id,
        [FromBody] UpdateTicketAgentDto dto)

    {
        try
        {
            var updatedTicket= await _ticketService.UpdateTicketAgentAsync(id, dto);

            if (updatedTicket == null)
            {
                return NotFound();
            }
            
            return Ok(updatedTicket);

        }

        catch(ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        
    }
}