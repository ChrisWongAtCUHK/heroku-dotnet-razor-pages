using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DotNetRazorPages.Entity;

public abstract class Repository<T>(DbContext context) : IRepository<T> where T : class
{
    private readonly DbContext _context = context;

    public async Task CreateAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _context.Add(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<(List<T>, int)> ReadAllFilterAsync(int skip, int take)
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
        ArgumentNullException.ThrowIfNull(entity);

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
            ArgumentNullException.ThrowIfNull(entity);

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
