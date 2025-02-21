using Microsoft.AspNetCore.Mvc.RazorPages;
using DotNetRazorPages.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace DotNetRazorPages.Pages.Customers;

public class IndexModel(Data.CustomerDbContext context) : PageModel
{
    private readonly Data.CustomerDbContext _context = context;

    public IList<Customer>? Customers { get; set; }

    public async Task OnGetAsync()
    {
        Customers = await _context.Customer.ToListAsync();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var contact = await _context.Customer.FindAsync(id);

        if (contact != null)
        {
            _context.Customer.Remove(contact);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage();
    }
}