using DotNetRazorPages.Models.HR;
using Microsoft.EntityFrameworkCore;

namespace DotNetRazorPages.Data.HR;

public class HRDbContext(DbContextOptions<HRDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MySqlEmployee>().HasNoKey();
    }

}
