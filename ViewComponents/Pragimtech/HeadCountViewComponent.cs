using DotNetRazorPages.Entity.Pragimtech;
using Microsoft.AspNetCore.Mvc;

namespace DotNetRazorPages.ViewComponents.Pragimtech;
public class HeadCountViewComponent(IEmployeeRepository employeeRepository) : ViewComponent
{
  private readonly IEmployeeRepository _employeeRepository = employeeRepository;

    public IViewComponentResult Invoke()
  {
    var result = _employeeRepository.EmployeeCountByDept();
    return View(result);
  }
}