using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetRazorPages.Pages.Aspsnippets.IPAddress;

public class IndexModel(IHttpContextAccessor accessor) : PageModel
{
    private IHttpContextAccessor _accessor { get; set; } = accessor;

    public void OnGet()
    {
        ViewData["IPAddress"] = _accessor.HttpContext!.Connection.RemoteIpAddress?.ToString();
    }
}