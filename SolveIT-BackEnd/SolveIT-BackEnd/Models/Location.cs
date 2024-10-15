using SolveIT_BackEnd.Enums;
using System.ComponentModel.DataAnnotations;

namespace SolveIT_BackEnd.Models;

public class Location : BaseModel
{
    [Required]
    public CompanyCountry Country { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public string City { get; set; }
    public string Name { get; set; }
}
