using Microsoft.EntityFrameworkCore;
using SolveIT_BackEnd.Data;
using System.Security.Claims;

namespace SolveIT_BackEnd.Middleware;

public class UserLookupMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IServiceProvider _serviceProvider;

    public UserLookupMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
    {
        _next = next;
        _serviceProvider = serviceProvider;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.User.Identity is ClaimsIdentity identity)
        {
            var userIdClaim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim != null)
            {
                var auth0Id = userIdClaim.Value;

                using (var scope = _serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Auth0Id == auth0Id);

                    if (user != null)
                    {
                        context.Items["User"] = user;
                    }
                    else
                    {
                        context.Response.StatusCode = 404;
                        await context.Response.WriteAsync("User not found.");
                        return;
                    }
                }
            }
            else
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized: No valid 'sub' claim found.");
                return;
            }
        }

        await _next(context);
    }
}
