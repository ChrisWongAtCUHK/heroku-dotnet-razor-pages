using Microsoft.AspNetCore.Mvc.RazorPages;
using DotNetRazorPages.Entity.Pragimtech;
using DotNetRazorPages.Models.Pragimtech;

namespace DotNetRazorPages.Pages.Pragimtech;
public class IndexModel(IEmployeeRepository employeeRepository) : PageModel
{
  private readonly IEmployeeRepository _employeeRepository = employeeRepository;

  public required IEnumerable<Employee> Employees { get; set; }


  public void OnGet()
  {
    Employees = _employeeRepository.GetAllEmployees();
  }
}