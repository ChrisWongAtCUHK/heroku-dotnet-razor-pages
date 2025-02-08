using Microsoft.EntityFrameworkCore;
using DotNetRazorPages.Models;
using System.Linq.Expressions;
using DotNetRazorPages.Data;

namespace DotNetRazorPages.Entity;

public class Repository<T>(MovieDbContext context) : IRepository<T> where T : class
{
    private readonly MovieDbContext _context = context;

    public async Task CreateAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _context.Add(entity);
        await _context.SaveChangesAsync();
    }
}
