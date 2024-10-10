using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolveIT_BackEnd.Models;
using System.Security.Claims;

namespace SolveIT_BackEnd.Controllers;

[ApiController]
public abstract class ApiBaseController : ControllerBase
{
    protected User GetCurrentUser()
    {
        var user = HttpContext.Items["User"] as User;
        if (user == null)
        {
            throw new KeyNotFoundException("User not found in the current context.");
        }
        return user;
    }
}
