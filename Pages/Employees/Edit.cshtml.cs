using DotNetRazorPages.Models;
using DotNetRazorPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetRazorPages.Pages.Employees;

public class EditModel(ILogger<EditModel> logger, IEmployeeRepository employeeRepository) : PageModel
{
  private readonly ILogger<EditModel> _logger = logger;

#pragma warning disable CS9124 // Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.
  private readonly IEmployeeRepository _employeeRepository = employeeRepository;
#pragma warning restore CS9124 // Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.

  [BindProperty]
  public required Employee Employee { get; set; }

  public IActionResult OnGet(int id)
  {
    Employee = _employeeRepository.GetEmployee(id);
    if (Employee == null)
    {
      return RedirectToPage("/NotFound");
    }

    return Page();
  }

  public IActionResult OnPost(Employee employee)
  {
    Employee = _employeeRepository.Update(employee);
    return RedirectToPage("Index");
  }
}
