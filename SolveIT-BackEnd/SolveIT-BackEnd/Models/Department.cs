using SolveIT_BackEnd.Enums;
using System.ComponentModel.DataAnnotations;

namespace SolveIT_BackEnd.Models;

public class Department : BaseModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    public int LocationId { get; set; }
    public Location Location { get; set; }
    public List<User> Users { get; set; }
    public List<Ticket> Tickets { get; set; }
}
