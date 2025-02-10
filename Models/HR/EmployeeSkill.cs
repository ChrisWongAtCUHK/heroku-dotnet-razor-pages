using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetRazorPages.Models.HR;

[Table("employeesSkills")]
public class EmployeeSkill
{
  public int EmployeeId { get; set; }
  public required Employee Employee { get; set; }
  public int SkillId { get; set; }
  public required Skill Skill { get; set; }
}