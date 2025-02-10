using DotNetRazorPages.Models.Pragimtech;

namespace DotNetRazorPages.Entity.Pragimtech;
public interface IEmployeeRepository
{
  IEnumerable<Employee> GetAllEmployees();
  Employee? GetEmployee(int id);
  Employee? Update(Employee updatedEmployee);
  Employee Add(Employee newEmployee);
}