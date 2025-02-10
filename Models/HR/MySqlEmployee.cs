using System.ComponentModel.DataAnnotations;

namespace DotNetRazorPages.Models.HR;
public class MySqlEmployee : Employee
{
  public required string Department { get; set; } 
  public new required string Skills { get; set; }
}
