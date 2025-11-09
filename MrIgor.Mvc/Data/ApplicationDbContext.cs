using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MrIgor.Core.Models;

namespace MrIgor.Mvc.Data;

// public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
// {
// }

public class ApplicationDbContext : IdentityDbContext<AspNetUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Add other DbSets if needed
    public DbSet<Tenant> Tenants { get; set; }
}