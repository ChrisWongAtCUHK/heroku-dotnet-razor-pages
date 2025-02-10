using DotNetRazorPages.Data.HR;
using DotNetRazorPages.Models.HR;
using Microsoft.EntityFrameworkCore;

namespace DotNetRazorPages.Entity.HR;

public class EmployeeRepository<T>(HRDbContext context) : Repository<T>(context) where T : class
{
    public override async Task<(List<T>, int)> ReadAllFilterAsync(int skip, int take)
    {
        var all = context.Set<T>();
        List<T> employees = [];
        await Task.Run(() =>
        {
            employees = [.. all.FromSqlRaw<T>("CALL get_employees({0}, {1})", skip, take)];
        });
        var total = all.Count();

        // the records along with the count of all the records in a Tuple.
        (List<T>, int) result = (employees, total);

        return result;
    }
}