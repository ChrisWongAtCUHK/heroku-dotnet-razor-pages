using DotNetRazorPages.Data.HR;
using Microsoft.EntityFrameworkCore;

namespace DotNetRazorPages.Entity.HR;

public class EmployeeRepository<T>(HRDbContext context) : Repository<T>(context) where T : class
{
    public override async Task<(List<T>, int)> ReadAllFilterAsync(int skip, int take)
    {
        var set = context.Set<T>();
        int total = 0;
        List<T> employees = [];
        await Task.Run(() =>
        {
            // make sure get_employees exists
            employees = [.. set.FromSqlRaw<T>("CALL get_employees({0}, {1})", skip, take)];

            // make sure get_total_employees_count exits
            total = set.FromSqlRaw<T>("""
                SELECT
                    DISTINCT e.id
                FROM
                    employees e
                INNER JOIN departments d ON d.id = e.departmentId
                LEFT JOIN employeesSkills es ON es.employeeId = e.id
                LEFT JOIN skills s ON s.id = es.skillId
            """).Count(); 
        });

        // the records along with the count of all the records in a Tuple.
        (List<T>, int) result = (employees, total);

        return result;
    }
}