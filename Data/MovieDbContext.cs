using DotNetRazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetRazorPages.Data;

public class MovieDbContext : DbContext
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movie { get; set; }
}

