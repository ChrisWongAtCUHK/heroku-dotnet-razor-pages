using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetRazorPages.Pages.Download;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public string Result { get; private set; } = "Download in C#";

    public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri("https://raw.githubusercontent.com");
        Result = await client.GetStringAsync("/aspsnippets/test/master/ReadMe.txt");
        return Page();
    }
}

