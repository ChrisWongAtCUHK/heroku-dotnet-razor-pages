using Microsoft.EntityFrameworkCore;
using DotNetRazorPages.Data.HR;
using System.Linq.Expressions;

namespace DotNetRazorPages.Entity.HR;

public class DepartmentRepository<T>(DepartmentDbContext context) : Repository<T>(context) where T : class
{
}
