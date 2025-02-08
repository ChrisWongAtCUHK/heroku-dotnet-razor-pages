namespace DotNetRazorPages.Entity;

public interface IRepository<T> where T : class
{
    Task CreateAsync(T entity);
}

