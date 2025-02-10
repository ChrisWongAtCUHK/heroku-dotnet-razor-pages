using System.ComponentModel.DataAnnotations;

namespace DotNetRazorPages.Models.HR;
public class MySqlEmployee
{
  public int Id { get; set; }
  [Required]
  public required string FirstName { get; set; }
  [Required]
  public required string LastName { get; set; }
  [Required]
  public required DateTime JoinedDate { get; set; }
  [Required]
  public required decimal Salary { get; set; }
  [Required]
  public required string DepartmentName { get; set; } 
  public required string Skills { get; set; }
}
