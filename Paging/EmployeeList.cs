using DotNetRazorPages.Models.HR;

namespace DotNetRazorPages.Paging;
public class EmployeeList
{
    public required IEnumerable<Employee> Employees { get; set; }
    public required PagingInfo PagingInfo { get; set; }
}
