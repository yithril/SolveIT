using Microsoft.EntityFrameworkCore;
using SolveIT_BackEnd.Models;

namespace SolveIT_BackEnd.Data;

public static class DataSeeder
{
    public static void SeedInitialData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRole>().HasData(
            new UserRole { Id = 1, Name = "Admin", CreatedById = 1, Description = "Whatevs", CreatedOn = DateTime.UtcNow },
            new UserRole { Id = 2, Name = "User", CreatedById = 1, Description = "Whatevs", CreatedOn = DateTime.UtcNow }
        );

        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "IT", CreatedById = 1, CreatedOn = DateTime.UtcNow, Address = "123 Street", City = "Nowhere" },
            new Department { Id = 2, Name = "HR", CreatedById = 1, CreatedOn = DateTime.UtcNow, Address = "123 Street", City = "Nowhere" }
        );

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                FirstName = "System",
                LastName = "Admin",
                Email = "admin@example.com",
                Auth0Id = "auth0|system-admin-id",
                DepartmentId = 1, 
                UserRoleId = 1,   
                CreatedById = 1,
                PhoneNumber = "123-456-9999",
                CreatedOn = DateTime.UtcNow,
                IsActive = true
            }
        );
    }
}
