using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetRazorPages.Models.HR;

[Table("skills")]
public class Skill
{
  public int Id { get; set; }
  [Required]
  public required string Title { get; set; }

  public List<Employee> Employees { get; set; } = [];
}