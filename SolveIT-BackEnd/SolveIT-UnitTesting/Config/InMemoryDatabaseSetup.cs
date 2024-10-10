using Microsoft.EntityFrameworkCore;
using SolveIT_BackEnd.Data;

namespace SolveIT_UnitTesting.Config;

public class InMemoryDatabaseSetup
{
    private DbContextOptions<AppDbContext> _options;

    public InMemoryDatabaseSetup()
    {
        _options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
    }

    public AppDbContext GetDbContext()
    {
        var context = new AppDbContext(_options);
        context.Database.EnsureCreated(); 
        return context;
    }
}
