using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SolveIT_BackEnd.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TicketUsersController : ControllerBase
{
}
