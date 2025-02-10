using DotNetRazorPages.Models.HR;

namespace DotNetRazorPages.Paging;
public class EmployeeList
{
    public required IEnumerable<MySqlEmployee> Employees { get; set; }
    public required PagingInfo PagingInfo { get; set; }
}
