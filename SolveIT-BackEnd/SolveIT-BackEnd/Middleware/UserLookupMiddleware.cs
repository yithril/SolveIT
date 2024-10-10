using Microsoft.EntityFrameworkCore;
using SolveIT_BackEnd.Data;

namespace SolveIT_BackEnd.Middleware;

public class UserLookupMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppDbContext _appDbContext;

    public UserLookupMiddleware(RequestDelegate next, AppDbContext appDbContext)
    {
        _next = next;
        _appDbContext = appDbContext;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.User.Identity?.IsAuthenticated == true)
        {
            var auth0Id = context.User.FindFirst("sub")?.Value;
            if (auth0Id != null)
            {
                var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Auth0Id == auth0Id);
                if (user != null)
                {
                    context.Items["User"] = user;
                }
            }
        }

        await _next(context);
    }
}
