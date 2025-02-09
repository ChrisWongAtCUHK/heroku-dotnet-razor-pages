using DotNetRazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetRazorPages.Data;

public class DepartmentDbContext(DbContextOptions<DepartmentDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employee { get; set; }

}
