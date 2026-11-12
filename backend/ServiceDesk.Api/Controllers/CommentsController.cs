namespace ServiceDesk.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Api.Services.Interfaces;
using ServiceDesk.Api.DTOs.Comments;

[ApiController]
[Route("api/tickets/{ticketId}/comments")]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentsController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTicketComments(int ticketId)
    {
        var comments = await _commentService.GetCommentsByTicketIdAsync(ticketId);

        return Ok(comments);
    }
    [HttpPost]
    public async Task<IActionResult> AddTicketComments(int ticketId, CreateCommentDto dto)
    {
        var comment = await _commentService.CreateCommentAsync(ticketId, dto);


        if (comment == null)
        {
            return NotFound("Ticket not found");
        }

        return Ok(comment);

    }

}