using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SolveIT_BackEnd.Controllers;

[ApiController]
public abstract class ApiBaseController : ControllerBase
{
    protected string GetCurrentUserId()
    {
        if (User.Identity is ClaimsIdentity identity)
        {
            // Extract the user ID from the claims (assuming it's stored in the "sub" claim)
            var userIdClaim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier || c.Type == "sub");
            if (userIdClaim != null)
            {
                return userIdClaim.Value;
            }
        }

        return null;
    }
}
