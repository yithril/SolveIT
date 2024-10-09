using SolveIT_BackEnd.Enums;
using SolveIT_BackEnd.Models.DTO;
using SolveIT_BackEnd.Models;
using SolveIT_BackEnd.Models.Mapper;

namespace SolveIT_UnitTesting.MapperTests;

public class TickerUserMapperTests
{
    [Test]
    public void FromCreateTicketUser_ShouldMapDtoToTicketUser()
    {
        var dto = new CreateTickerUserDto
        {
            TicketId = 1,
            UserId = 2,
            Role = TicketUserRole.Support
        };

        var ticketUser = dto.FromCreateTicketUser();

        Assert.That(ticketUser.TicketId, Is.EqualTo(1));
        Assert.That(ticketUser.UserId, Is.EqualTo(2));
        Assert.That(ticketUser.Role, Is.EqualTo(TicketUserRole.Support));
    }

    [Test]
    public void ToDto_ShouldMapTicketUserToDto()
    {
        var user = new TicketUser
        {
            Id = 1,
            Role = TicketUserRole.Support,
            TicketId = 1
        };

        // Act
        var dto = user.ToDto();

        // Assert
        Assert.That(dto.TicketId, Is.EqualTo(1));
        Assert.That(dto.Role, Is.EqualTo(TicketUserRole.Support));
        Assert.IsNull(dto.User);
    }
}
