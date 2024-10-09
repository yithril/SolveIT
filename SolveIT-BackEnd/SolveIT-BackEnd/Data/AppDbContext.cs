using Microsoft.EntityFrameworkCore;
using SolveIT_BackEnd.Models;

namespace SolveIT_BackEnd.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Comment> Comments { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> Roles { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Ticket> Ticket { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(x => x.ReportsTo)
            .WithMany(x => x.Subordinates)
            .HasForeignKey(x => x.ReportsToId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
