﻿using Microsoft.EntityFrameworkCore;
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

        modelBuilder.Entity<User>()
            .HasOne(x => x.UserRole)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.UserRoleId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasOne(x => x.Department)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasOne(x => x.CreatedBy)
            .WithMany()  
            .HasForeignKey(x => x.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasOne(x => x.UpdatedBy)
            .WithMany()  
            .HasForeignKey(x => x.UpdatedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserRole>()
            .HasOne(x => x.CreatedBy)
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserRole>()
            .HasOne(x => x.UpdatedBy)
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserRole>()
            .HasMany(x => x.Users)
            .WithOne(x => x.UserRole)
            .HasForeignKey(x => x.UserRoleId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Department>()
            .HasOne(d => d.CreatedBy)
            .WithMany()  
            .HasForeignKey(d => d.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Department>()
            .HasOne(d => d.UpdatedBy)
            .WithMany()  
            .HasForeignKey(d => d.UpdatedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Department>()
            .HasMany(d => d.Users)
            .WithOne(u => u.Department)
            .HasForeignKey(u => u.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TicketUser>()
            .HasOne(tu => tu.Ticket)
            .WithMany(t => t.TicketUsers)
            .HasForeignKey(tu => tu.TicketId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TicketUser>()
            .HasOne(tu => tu.User)
            .WithMany()
            .HasForeignKey(tu => tu.UserId)
            .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<TicketUser>()
            .HasOne(tu => tu.CreatedBy)
            .WithMany()
            .HasForeignKey(tu => tu.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TicketUser>()
            .HasOne(tu => tu.UpdatedBy)
            .WithMany()
            .HasForeignKey(tu => tu.UpdatedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Ticket)
            .WithMany(t => t.Comments)
            .HasForeignKey(c => c.TicketId)
            .OnDelete(DeleteBehavior.Cascade);  

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.CreatedBy)
            .WithMany() 
            .HasForeignKey(c => c.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.UpdatedBy)
            .WithMany() 
            .HasForeignKey(c => c.UpdatedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Ticket>()
            .HasOne(x => x.Department)
            .WithMany(x => x.Tickets)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
