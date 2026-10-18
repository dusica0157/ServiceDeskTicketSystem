using ServiceDesk.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
        
    }

   public DbSet<User> Users { get; set; } = null!;

public DbSet<Ticket> Tickets { get; set; } = null!;

public DbSet<Category> Categories { get; set; } = null!;

public DbSet<Comment> Comments { get; set; } = null!;


protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

   modelBuilder.Entity<Ticket>()
    .HasOne(ticket => ticket.CreatedByUser)
    .WithMany(user => user.CreatedTickets)
    .HasForeignKey(ticket => ticket.CreatedByUserId)
    .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Ticket>()
    .HasOne(ticket=> ticket.AssignedAgent)
    .WithMany(user => user.AssignedTickets)
    .HasForeignKey(ticket => ticket.AssignedAgentId )
    .OnDelete(DeleteBehavior.Restrict);
}
}