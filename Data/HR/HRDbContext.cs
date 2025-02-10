using DotNetRazorPages.Models.HR;
using Microsoft.EntityFrameworkCore;

namespace DotNetRazorPages.Data.HR;

public class HRDbContext(DbContextOptions<HRDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Skill> Skills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>()
            .HasOne(e => e.Employee)
            .WithOne(e => e.Department)
            .HasForeignKey<Employee>(e => e.DepartmentId)
            .IsRequired();

        modelBuilder.Entity<Skill>()
                .HasMany(e => e.Employees)
                .WithMany(e => e.Skills)
                .UsingEntity(
                        "SkillEmployee",
                        l => l.HasOne(typeof(Employee)).WithMany().HasForeignKey("EmployeeId").HasPrincipalKey(nameof(Employee.Id)),
                        r => r.HasOne(typeof(Skill)).WithMany().HasForeignKey("SkillId").HasPrincipalKey(nameof(Skill.Id)),
                        j => j.HasKey("EmployeeId", "SkillId"));
    }

}
