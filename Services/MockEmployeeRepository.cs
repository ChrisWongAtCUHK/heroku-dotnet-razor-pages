using DotNetRazorPages.Models;

namespace DotNetRazorPages.Services;

public class MockEmployeeRepository : IEmployeeRepository
{
  private List<Employee> _employeeList;

  public MockEmployeeRepository()
  {
    _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Mary", Department = Dept.HR,
                    Email = "mary@pragimtech.com", PhotoPath="mary.png" },
                new Employee() { Id = 2, Name = "John", Department = Dept.IT,
                    Email = "john@pragimtech.com", PhotoPath="john.png" },
                new Employee() { Id = 3, Name = "Sara", Department = Dept.IT,
                    Email = "sara@pragimtech.com", PhotoPath="sara.png" },
                new Employee() { Id = 4, Name = "David", Department = Dept.Payroll,
                    Email = "david@pragimtech.com" },
            };
  }

  public IEnumerable<Employee> GetAllEmployees()
  {
    return _employeeList;
  }

  public Employee GetEmployee(int id)
  {

#pragma warning disable CS8603 // Possible null reference return.
    return _employeeList!.FirstOrDefault(e => e!.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
  }

  public Employee Update(Employee updatedEmployee)
  {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
    Employee employee = _employeeList
    .FirstOrDefault(e => e.Id == updatedEmployee.Id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
    if (employee != null)
    {
      employee.Name = updatedEmployee.Name;
      employee.Email = updatedEmployee.Email;
      employee.Department = updatedEmployee.Department;
    }
    else
    {
      employee = new()
      {
        Name = "",
        Email = ""
      };
    }
    return employee;
  }
}
