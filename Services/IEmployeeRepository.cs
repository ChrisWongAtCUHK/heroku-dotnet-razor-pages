using DotNetRazorPages.Models;

namespace DotNetRazorPages.Services;
public interface IEmployeeRepository
{
  IEnumerable<Employee> GetAllEmployees();
  Employee GetEmployee(int id);
}
