using DotNetRazorPages.Models.Pragimtech;

namespace DotNetRazorPages.Entity.Pragimtech;
public interface IEmployeeRepository
{
  List<Employee> GetAllEmployees();
  Employee? GetEmployee(int id);
  Employee? Update(List<Employee> employees, Employee updatedEmployee);
  Employee Add(List<Employee> employees, Employee newEmployee);
  Employee Delete(List<Employee> employees, int id);
  IEnumerable<DeptHeadCount> EmployeeCountByDept();
   IEnumerable<Employee> Search(string searchTerm);
}