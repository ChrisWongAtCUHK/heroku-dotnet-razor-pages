using DotNetRazorPages.Models.HR;
using Microsoft.EntityFrameworkCore;

namespace DotNetRazorPages.Data.HR;

public class HRDbContext(DbContextOptions<HRDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; }
     public DbSet<Department> Departments { get; set; }

}
