using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DotNetRazorPages.Entity.Pragimtech;
using DotNetRazorPages.Models.Pragimtech;

namespace DotNetRazorPages.Pages.Pragimtech;
public class DetailsModel(IEmployeeRepository employeeRepository) : PageModel
{
  private readonly IEmployeeRepository _employeeRepository = employeeRepository;

  public Employee? Employee { get; set; }
  public required IEnumerable<Employee> Employees { get; set; }

  [BindProperty(SupportsGet = true)]
  public string? Message { get; set; }

  // Model-binding automatically maps the query string id
  // value to the id parameter on this OnGet() method
  public void OnGet(int id)
  {
    Employee = _employeeRepository.GetEmployee(id);
  }
}