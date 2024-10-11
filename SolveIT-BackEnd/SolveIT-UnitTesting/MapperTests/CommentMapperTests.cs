using SolveIT_BackEnd.Models;
using SolveIT_BackEnd.Models.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveIT_UnitTesting.MapperTests;

[TestFixture]
public class CommentMapperTests
{
    [Test]
    public void Comment_ToDto_Succeeds()
    {
        Comment comment = new()
        {
            Id = 1,
            TicketId = 1
        };

        var result = comment.ToDto();

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(1));
        Assert.That(result.TicketId, Is.EqualTo(1));
    }
}
