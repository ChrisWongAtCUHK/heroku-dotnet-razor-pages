using System.ComponentModel.DataAnnotations;

namespace DotNetRazorPages.Models;

public class Employee
{
  public int Id { get; set; }
  [Required(ErrorMessage = "Name is required"), MinLength(3, ErrorMessage = "Name must contain at least 3 characters")]
  public required string Name { get; set; }
  [Display(Name = "Office Email")]
  [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
       ErrorMessage = "Invalid email format")]
  [Required]
  public required string Email { get; set; }
  public string? PhotoPath { get; set; }
  public Dept? Department { get; set; }
}
