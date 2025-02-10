using DotNetRazorPages.Models.Pragimtech;

namespace DotNetRazorPages.Entity.Pragimtech;

public class MockEmployeeRepository : IEmployeeRepository
{
  private readonly List<Employee> _employeeList;

  public MockEmployeeRepository()
  {
    _employeeList =
    [
        new Employee() { Id = 1, Name = "Mary", Department = Dept.HR,
                Email = "mary@pragimtech.com", PhotoPath="mary.png" },
            new Employee() { Id = 2, Name = "John", Department = Dept.IT,
                Email = "john@pragimtech.com", PhotoPath="john.png" },
            new Employee() { Id = 3, Name = "Sara", Department = Dept.IT,
                Email = "sara@pragimtech.com", PhotoPath="sara.png" },
            new Employee() { Id = 4, Name = "David", Department = Dept.Payroll,
                Email = "david@pragimtech.com" },
        ];
  }

  public List<Employee> GetAllEmployees()
  {
    return _employeeList;
  }

  public Employee? GetEmployee(int id)
  {
    return _employeeList.FirstOrDefault(e => e.Id == id);
  }

  public Employee? Update(List<Employee> employees, Employee updatedEmployee)
  {
    Employee? employee = employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);

    if (employee != null)
    {
      employee.Name = updatedEmployee.Name;
      employee.Email = updatedEmployee.Email;
      employee.Department = updatedEmployee.Department;
      employee.PhotoPath = updatedEmployee.PhotoPath;
    }

    return employee ?? new Employee()
    {
      Name = string.Empty,
      Email = string.Empty
    };
  }

  public Employee Add(List<Employee> employees, Employee newEmployee)
  {
    newEmployee.Id = _employeeList.Max(e => e.Id) + 1;
    employees.Add(newEmployee);
    return newEmployee;
  }

  public Employee Delete(List<Employee> employees, int id)
  {
    var employee = employees.FirstOrDefault(e => e.Id == id) ?? new Employee()
    {
      Name = string.Empty,
      Email = string.Empty
    };
    _ = employees.Remove(employee);
    return employee;
  }
}