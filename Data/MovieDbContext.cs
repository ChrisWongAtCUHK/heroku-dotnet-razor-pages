using DotNetRazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetRazorPages.Data;

public class MovieDbContext(DbContextOptions<MovieDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movie { get; set; }
}

