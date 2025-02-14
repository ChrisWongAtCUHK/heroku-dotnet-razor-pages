using System.Net;
using DotNetRazorPages.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetRazorPages.Pages.Aspsnippets.Email.Attachment;

public class IndexModel(IConfiguration configuration) : PageModel
{
    public IConfiguration _configuration = configuration;
    public EmailModel? EmailModel { get; set; }

    public void OnGet()
    {
    }

    public void OnPostSendEmail(EmailModel emailModel)
    {
        //Setting TLS 1.2 protocol.
#pragma warning disable SYSLIB0014 // Type or member is obsolete
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
#pragma warning restore SYSLIB0014 // Type or member is obsolete
        using HttpClient client = new HttpClient();
        string apiUrl = "https://raw.githubusercontent.com/aspsnippets/test/master/Sample.pdf";

        //Read the file to Stream from URL.
        using Stream stream = client.GetStreamAsync(apiUrl).Result;

        emailModel.IsBodyHtml = false;
        emailModel.Attachment = new System.Net.Mail.Attachment(stream, Path.GetFileName(apiUrl));
        emailModel.SendEmail(_configuration);

         ViewData["Message"] = "Email sent with attachment.";
    }
}
