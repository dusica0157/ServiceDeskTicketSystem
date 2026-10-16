
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Xml;
using  ServiceDesk.Api.Enums;

namespace ServiceDesk.Api.Models;


public class Ticket
{
    public int Id{get; set;}

    public string Title {get; set;} = string.Empty;

    public string Description {get; set;} = string.Empty;

    public TicketStatus Status {get; set;} = TicketStatus.Open;
    
    public TicketPriority Priority {get; set;} = TicketPriority.Medium;

    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;

    public int CreatedByUserId {get; set;}

    public User  CreatedByUser {get; set;}= null!;
    
    public int? AssignedAgentId {get; set;}
    public User? AssignedAgent {get; set;}

    public Category Category  {get; set;} = null!;

    public ICollection<Ticket> CreatedTickets {get; set;} = new List<Ticket>();

    public ICollection<Ticket> AssignedTickets {get; set;} = new List<Tickets>();

    public ICollection<Comment> Comments { get; set;} = new List<XmlComment>();

} 