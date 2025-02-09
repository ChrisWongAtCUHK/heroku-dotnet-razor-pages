using System.ComponentModel.DataAnnotations.Schema;
using DotNetRazorPages.Entity;

namespace DotNetRazorPages.Models.HR;

[Table("departments")]
public class Department
{
  public int Id { get; set; }
  public required string Name { get; set; }

  public static IRepository<Department>? _repository;

  public Department()
  {
  }

  public Department(IRepository<Department> repository)
  {
    _repository = repository;
  }

  public static async Task<Department?> ReadAsync(IRepository<Department> repository, int id)
  {
    var department = await repository!.ReadAsync(id);
    return department;
  }
}