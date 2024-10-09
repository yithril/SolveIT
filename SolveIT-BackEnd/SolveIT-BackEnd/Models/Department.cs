using SolveIT_BackEnd.Enums;
using System.ComponentModel.DataAnnotations;

namespace SolveIT_BackEnd.Models;

public class Department : BaseModel
{
    [Required]
    public CompanyCountry Country { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string Name { get; set; }
    public List<User> Users { get; set; }
}
