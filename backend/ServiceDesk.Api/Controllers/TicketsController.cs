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
        var ticket= await _ticketService.GetTicketByIdAsync(id);

        if(ticket == null)
        {
            return NotFound();

        }
        return Ok(ticket);
    }
}