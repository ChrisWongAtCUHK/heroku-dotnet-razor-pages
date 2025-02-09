using DotNetRazorPages.Data;

namespace DotNetRazorPages.Entity;

public class MovieRepository<T>(MovieDbContext context) : Repository<T>(context) where T : class
{
}
