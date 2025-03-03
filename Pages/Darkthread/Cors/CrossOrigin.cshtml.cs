using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetRazorPages.Pages.Darkthread.Cors;

public class CrossOriginModel(IWebHostEnvironment webHostEnvironment) : PageModel
{
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

    public string Origin = "";

    public void OnGet()
    {
        if (_webHostEnvironment.IsDevelopment())
        {
            Origin = Request.Scheme + "://" + Request.Host.ToString();
        }
        else
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            Origin = config["Origin"]!;
        }
    }
}
