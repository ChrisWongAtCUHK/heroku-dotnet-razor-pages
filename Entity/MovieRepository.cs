using Microsoft.EntityFrameworkCore;
using DotNetRazorPages.Data;
using System.Linq.Expressions;

namespace DotNetRazorPages.Entity;

public class MovieRepository<T>(MovieDbContext context) : IRepository<T> where T : class
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
        var all = _context.Set<T>();
        // fetching only the records of the current page by the use of Linq Skip and Take methods
        var relevant = await all.Skip(skip).Take(take).ToListAsync();
        var total = all.Count();

        // the records along with the count of all the records in a Tuple.
        (List<T>, int) result = (relevant, total);

        return result;
    }
    public async Task UpdateAsync(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
    public async Task<T?> ReadAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> ReadAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<List<T>> ReadAllAsync(Expression<Func<T, bool>> filter)
    {
        return await _context.Set<T>().Where(filter).ToListAsync();
    }
}
