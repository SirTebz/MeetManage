using MeetManage.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeetManage.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<MeetingRequest> meetingRequests { get; set; }
    public DbSet<Users> users { get; set; }
    public DbSet<Invitation> Invitations { get; set; }
    public DbSet<Event> Events { get; set; }
}
