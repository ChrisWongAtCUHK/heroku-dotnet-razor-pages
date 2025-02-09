using DotNetRazorPages.Models.HR;
using Microsoft.EntityFrameworkCore;

namespace DotNetRazorPages.Data.HR;

public class DepartmentDbContext(DbContextOptions<DepartmentDbContext> options) : DbContext(options)
{
    public DbSet<Department> Departments { get; set; }

}
