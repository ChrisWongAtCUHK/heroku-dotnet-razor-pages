using DotNetRazorPages.Data.HR;

namespace DotNetRazorPages.Entity.HR;

public class EmployeeRepository<T>(HRDbContext context) : Repository<T>(context) where T : class
{
}