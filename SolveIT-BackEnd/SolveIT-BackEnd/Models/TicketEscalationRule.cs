using SolveIT_BackEnd.Enums;
using System.ComponentModel.DataAnnotations;

namespace SolveIT_BackEnd.Models;

public class TicketEscalationRule : BaseModel
{
    public int DepartmentId { get; set; }

    [Required]
    public Department Department { get; set; }

    public int StartingUserRoleId { get; set; }

    [Required]
    public UserRole StartingUserRole { get; set; }

    public int NextUserRoleId { get; set; }

    [Required]
    public UserRole NextUserRole { get; set; }

    public TicketType TicketType { get; set; }

    public bool IsFinalLevel { get; set; }

    public int Threshhold { get; set; }   
}
