using SolveIT_BackEnd.Models;
using SolveIT_BackEnd.Models.DTO;

namespace SolveIT_BackEnd.Mapper;

public static class TicketUserMapper
{
    public static TicketUserDto ToDto(this TicketUser ticketUser) => new(ticketUser.Id, ticketUser.User, ticketUser.Role);
}
