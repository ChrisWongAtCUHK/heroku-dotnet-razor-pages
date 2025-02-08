namespace DotNetRazorPages.Entity;

public interface IRepository<T> where T : class
{
    Task CreateAsync(T entity);
    Task<(List<T>, int)> ReadAllFilterAsync(int skip, int take);
    Task DeleteAsync(int id);
}

