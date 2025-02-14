using System.Net;
using System.Net.Mail;
using DotNetRazorPages.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetRazorPages.Pages.Aspsnippets.Email.Html;

public class IndexModel(IConfiguration configuration, IWebHostEnvironment environment) : PageModel
{
    public IConfiguration _configuration = configuration;
    private readonly IWebHostEnvironment _environment = environment;
    public EmailModel? EmailModel { get; set; }

    public void OnGet()
    {
    }

    public void OnPostSendEmail(EmailModel emailModel)
    {
        emailModel.IsBodyHtml = true;
        string title = "ASP.Net Core 7 Razor Pages: Hello World Tutorial with Sample Program example";
        string url = "https://www.aspsnippets.com/Articles/4384/ASPNet-Core-7-Razor-Pages-Hello-World-Tutorial-with-Sample-Program-example/";
        string description = "Here Mudassar Khan has provided a short Hello World Tutorial using a small Sample Program example on how to use and develop applications in ASP.Net Core Razor Pages 7.0 for the first time.";
        emailModel.Body = PopulateBody("John", title, url, description);
        emailModel.SendEmail(_configuration);

        ViewData["Message"] = "Email sent with HTML Templates.";
    }

    private string PopulateBody(string userName, string title, string url, string description)
    {
        string body = string.Empty;
        string path = Path.Combine(_environment.WebRootPath, "Template");
        path = Path.Combine(path, "EmailTemplate.htm");
        using (StreamReader reader = new(path))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{UserName}", userName);
        body = body.Replace("{Title}", title);
        body = body.Replace("{Url}", url);
        body = body.Replace("{Description}", description);
        return body;
    }
}
