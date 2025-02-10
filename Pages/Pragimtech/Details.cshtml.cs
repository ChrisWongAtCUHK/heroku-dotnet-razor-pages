using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DotNetRazorPages.Entity.Pragimtech;
using DotNetRazorPages.Models.Pragimtech;

namespace DotNetRazorPages.Pages.Pragimtech;
public class DetailsModel(IEmployeeRepository employeeRepository) : PageModel
{
#pragma warning disable CS9124 // Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;
#pragma warning restore CS9124 // Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.

    public Employee? Employee { get; set; }

  [BindProperty(SupportsGet = true)]
  public string? Message { get; set; }

  // Model-binding automatically maps the query string id
  // value to the id parameter on this OnGet() method
  public void OnGet(int id)
  {
    Employee = employeeRepository.GetEmployee(id);
  }
}