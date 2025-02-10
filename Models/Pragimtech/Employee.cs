using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetRazorPages.Models.Pragimtech;
public class Employee
{
  public int Id { get; set; }
  [Required, MinLength(3, ErrorMessage = "Name must contain at least 3 characters")]
  public required string Name { get; set; }
  [Required]
  [Display(Name = "Office Email")]
  [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
  ErrorMessage = "Invalid email format")]
  public required string Email { get; set; }
  public string? PhotoPath { get; set; }
  [Required]
  public Dept? Department { get; set; }
}
