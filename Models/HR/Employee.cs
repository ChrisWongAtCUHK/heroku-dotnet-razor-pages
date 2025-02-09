using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetRazorPages.Models.HR;
[Table("employees")]
public class Employee
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
  public int DepartmentId { get; set; }
  public Department? Department { get; set; }
}
