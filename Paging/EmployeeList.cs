using DotNetRazorPages.Models;

namespace DotNetRazorPages.Paging;
public class EmployeeList
{
    public required IEnumerable<Employee> Employees { get; set; }
    public required PagingInfo PagingInfo { get; set; }
}
