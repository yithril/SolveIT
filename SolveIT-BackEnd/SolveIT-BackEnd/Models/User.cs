using System.ComponentModel.DataAnnotations;

namespace SolveIT_BackEnd.Models;

public class User : BaseModel
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    [Phone]
    public string PhoneNumber { get; set; }

    public string Auth0Id { get; set; }

    [Required]
    public Department Department { get; set; }
    public int DepartmentId { get; set; }

    [Required]
    public UserRole UserRole { get; set; }
    public int UserRoleId { get; set; }
    
    public int? ReportsToId { get; set; }
    public User ReportsTo {  get; set; }

    public List<User> Subordinates { get; set; }
}
