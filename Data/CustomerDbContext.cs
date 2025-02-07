using Microsoft.EntityFrameworkCore;

namespace DotNetRazorPages.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext (DbContextOptions<CustomerDbContext> options)
            : base(options)
        {
        }

        public DbSet<DotNetRazorPages.Models.Customer> Customer => Set<DotNetRazorPages.Models.Customer>();
    }
}