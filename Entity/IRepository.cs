using System.Linq.Expressions;

namespace DotNetRazorPages.Entity;

public interface IRepository<T> where T : class
{
    Task CreateAsync(T entity);
    // return a list of records of the current page and total number of records in the database
    public Task<(List<T>, int)> ReadAllFilterAsync(int skip, int take);
    Task UpdateAsync(T entity);
    Task<T?> ReadAsync(int id);
    Task DeleteAsync(int id);
    Task<List<T>> ReadAllAsync();
    Task<(List<T>, int)> ReadAllAsync(string searchTerm, int skip, int take);
}

