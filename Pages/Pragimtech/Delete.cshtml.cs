using Microsoft.AspNetCore.Mvc.RazorPages;
using DotNetRazorPages.Entity.Pragimtech;
using DotNetRazorPages.Models.Pragimtech;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace DotNetRazorPages.Pages.Pragimtech;
public class DeleteModel(IEmployeeRepository employeeRepository) : PageModel
{
#pragma warning disable CS9124 // Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;
#pragma warning restore CS9124 // Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.

    [BindProperty]
  public required Employee Employee { get; set; }
  public required List<Employee> Employees { get; set; }


  public IActionResult OnGet(int id)
  {
    Employees = _employeeRepository.GetAllEmployees();
    var tempData = TempData["Employees"] ?? string.Empty;
    if (!string.IsNullOrEmpty((string?)tempData))
    {
      Employees = JsonConvert.DeserializeObject<List<Employee>>((string)tempData);
    }
    TempData["Employees"] = JsonConvert.SerializeObject(Employees);

    Employee = employeeRepository.GetEmployee(id) ?? new Employee()
    {
      Name = string.Empty,
      Email = string.Empty
    };

    if (string.IsNullOrEmpty(Employee.Name))
    {
      return RedirectToPage("/NotFound");
    }

    return Page();
  }

  public IActionResult OnPost()
  {
    var tempData = TempData["Employees"] ?? string.Empty;
    if (!string.IsNullOrEmpty((string?)tempData))
    {
      Employees = JsonConvert.DeserializeObject<List<Employee>>((string)tempData);
    }
    TempData["Employees"] = JsonConvert.SerializeObject(Employees);

    Employee employee = employeeRepository.Delete(Employees, Employee.Id);

    TempData["Employees"] = JsonConvert.SerializeObject(Employees);

    if (employee == null)
    {
      return RedirectToPage("/NotFound");
    }

    return RedirectToPage("Index");
  }
}