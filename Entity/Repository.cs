using Microsoft.EntityFrameworkCore;
using DotNetRazorPages.Data;

namespace DotNetRazorPages.Entity;

public class Repository<T>(MovieDbContext context) : IRepository<T> where T : class
{
#pragma warning disable CS9124 // Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.
    private readonly MovieDbContext _context = context;
#pragma warning restore CS9124 // Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.

    public async Task CreateAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _context.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<(List<T>, int)> ReadAllFilterAsync(int skip, int take)
    {
        var all = context.Set<T>();
        // fetching only the records of the current page by the use of Linq Skip and Take methods
        var relevant = await all.Skip(skip).Take(take).ToListAsync();
        var total = all.Count();

        // the records along with the count of all the records in a Tuple.
        (List<T>, int) result = (relevant, total);

        return result;
    }
    public async Task DeleteAsync(int id)
    {
        var entity = await context.Set<T>().FindAsync(id);
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }
}
