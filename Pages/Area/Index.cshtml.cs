using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetRazorPages.Pages.Area;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public string Message { get; private set; } = "Creating RazorPage apps using the CLI";
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }


    public void OnGet()
    {
        Message += $" Server time is {DateTime.Now}";
    }
}
