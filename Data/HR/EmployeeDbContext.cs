using DotNetRazorPages.Models.HR;
using Microsoft.EntityFrameworkCore;

namespace DotNetRazorPages.Data.HR;

public class EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; }

}
