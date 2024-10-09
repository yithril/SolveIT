using SolveIT_BackEnd.Models.DTO;

namespace SolveIT_BackEnd.Models.Mapper;

public static class TickerUserMapper
{
    public static TicketUser FromCreateTicketUser(this CreateTickerUserDto dto) => new()
    {
        TicketId = dto.TicketId,
        UserId = dto.UserId,
        Role = dto.Role
    };

    public static TicketUserDto ToDto(this TicketUser tickerUser) => new()
    {
        TicketId = tickerUser.TicketId,
        Role = tickerUser.Role
    };
}
