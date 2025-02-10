using Microsoft.AspNetCore.Mvc.RazorPages;
using DotNetRazorPages.Entity.Pragimtech;
using DotNetRazorPages.Models.Pragimtech;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace DotNetRazorPages.Pages.Pragimtech;
public class IndexModel(IEmployeeRepository employeeRepository) : PageModel
{
  private readonly IEmployeeRepository _employeeRepository = employeeRepository;

  public required List<Employee> Employees { get; set; }

  [BindProperty(SupportsGet = true)]
  public string? SearchTerm { get; set; }
  public void OnGet()
  {
    Employees = _employeeRepository.GetAllEmployees();
    var tempData = TempData["Employees"] ?? string.Empty;
    if (!string.IsNullOrEmpty((string?)tempData))
    {
      Employees = JsonConvert.DeserializeObject<List<Employee>>((string)tempData);
    }
    TempData["Employees"] = JsonConvert.SerializeObject(Employees);
    if (!string.IsNullOrEmpty(SearchTerm))
    {
      Employees = (List<Employee>)_employeeRepository.Search(SearchTerm);
    }
  }
}