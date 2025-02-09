using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using DotNetRazorPages.Entity;

namespace DotNetRazorPages.Models.HR;

[Table("departments")]
public class Department(IRepository<Department> repository)
{
  public int Id { get; set; }
  public required string Name { get; set; }

  public required IRepository<Department>? _repository = repository;

    public static async Task<Department?> ReadAsync(IRepository<Department> repository, int id)
  {
    var department = await repository!.ReadAsync(id);
    return department;
  }
}