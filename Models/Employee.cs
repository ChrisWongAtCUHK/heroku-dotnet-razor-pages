using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetRazorPages.Models;
[Table("employees")]
public class Employee(int id)
{
  public int Id { get; set; } = id;
  public required string FirstName { get; set; }
  public required string LastName { get; set; }
  public required DateTime JoinedDate { get; set; }
  public required decimal Salary { get; set; }
  public int DepartmentId { get; set; }
  public Department? Department { get; set; }
}
