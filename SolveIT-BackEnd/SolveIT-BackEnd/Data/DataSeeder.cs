using Microsoft.EntityFrameworkCore;
using SolveIT_BackEnd.Enums;
using SolveIT_BackEnd.Models;

namespace SolveIT_BackEnd.Data;

public static class DataSeeder
{
    public static void SeedInitialData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>().HasData(
            new Location { Id = 1, Country = CompanyCountry.USA, Address = "123 Tech Street", City = "New York", Name = "New York Office", CreatedById = 1, CreatedOn = DateTime.UtcNow },
            new Location { Id = 2, Country = CompanyCountry.USA, Address = "456 HR Blvd", City = "Los Angeles", Name = "Los Angeles Office", CreatedById = 1, CreatedOn = DateTime.UtcNow }
        );

        modelBuilder.Entity<UserRole>().HasData(
            new UserRole { Id = 1, Name = "Admin", CreatedById = 1, Description = "Whatevs", CreatedOn = DateTime.UtcNow },
            new UserRole { Id = 2, Name = "User", CreatedById = 1, Description = "Whatevs", CreatedOn = DateTime.UtcNow }
        );

        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "IT", LocationId = 1, CreatedById = 1, CreatedOn = DateTime.UtcNow }, // New York Office
            new Department { Id = 2, Name = "HR", LocationId = 2, CreatedById = 1, CreatedOn = DateTime.UtcNow }  // Los Angeles Office
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
