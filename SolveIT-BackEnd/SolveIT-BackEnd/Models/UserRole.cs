using System.ComponentModel.DataAnnotations;

namespace SolveIT_BackEnd.Models;

public class UserRole : BaseModel
{
    [Required]
    public string Name { get; set; }
    public List<User> Users { get; set; }
}
