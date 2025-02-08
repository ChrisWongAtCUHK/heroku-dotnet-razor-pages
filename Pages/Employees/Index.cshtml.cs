using DotNetRazorPages.Models;
using DotNetRazorPages.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetRazorPages.Pages.Employees;

public class IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, IEmployeeRepository employeeRepository) : PageModel
{
  private readonly ILogger<IndexModel> _logger = logger;
  public IConfiguration _configuration { get; set; } = configuration;

  private readonly IEmployeeRepository _employeeRepository = employeeRepository;

  public required IEnumerable<Employee> Employees { get; set; }

  public void OnGet(int id)
  {
    Employees = _employeeRepository.GetAllEmployees();
  }

}
