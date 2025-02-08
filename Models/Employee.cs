namespace DotNetRazorPages.Models;

public class Employee
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public required string Email { get; set; }
  public string? PhotoPath { get; set; }
  public Dept? Department { get; set; }
}
