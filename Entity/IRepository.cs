namespace DotNetRazorPages.Entity;

public interface IRepository<T> where T : class
{
    Task CreateAsync(T entity);
    // return a list of records of the current page and total number of records in the database
    Task<(List<T>, int)> ReadAllFilterAsync(int skip, int take);
    Task DeleteAsync(int id);
}

