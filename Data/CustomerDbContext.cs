using DotNetRazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetRazorPages.Data;

public class CustomerDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public CustomerDbContext (DbContextOptions<CustomerDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customer => Set<Customer>();

    
}
