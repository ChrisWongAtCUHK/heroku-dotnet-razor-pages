using DotNetRazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetRazorPages.Data;

public class EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employee { get; set; }

}
