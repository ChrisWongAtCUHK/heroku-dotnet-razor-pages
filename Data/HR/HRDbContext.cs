using DotNetRazorPages.Models.HR;
using Microsoft.EntityFrameworkCore;

namespace DotNetRazorPages.Data.HR;

public class HRDbContext(DbContextOptions<HRDbContext> options) : DbContext(options)
{
     public virtual DbSet<MySqlEmployee> GetEmployees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MySqlEmployee>().HasNoKey();
        modelBuilder.Entity<Skill>()
                .HasMany(e => e.Employees)
                .WithMany(e => e.Skills)
                .UsingEntity(j => j.ToTable("EmployeesSkills"));
    }

}
