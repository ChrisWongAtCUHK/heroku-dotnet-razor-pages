using System.Net;
using System.Net.Mail;
using DotNetRazorPages.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetRazorPages.Pages.Aspsnippets.Email;

public class IndexModel(ILogger<IndexModel> logger, IConfiguration configuration) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    public IConfiguration _configuration { get; set; } = configuration;
    public EmailModel? Model { get; set; }

    public void OnGet()
    {
    }

    public void OnPostSendEmail(EmailModel model)
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
        //Read SMTP section from AppSettings.json.
        string? host = _configuration.GetValue<string>("Smtp:Server");
        int port = _configuration.GetValue<int>("Smtp:Port");
        bool enableSsl = _configuration.GetValue<bool>("Smtp:EnableSsl");
        bool defaultCredentials = _configuration.GetValue<bool>("Smtp:DefaultCredentials");

        using (MailMessage mm = new MailMessage(model.Email, model.To))
        {
            mm.Subject = model.Subject;
            mm.Body = model.Body;
            mm.IsBodyHtml = false;

            //Attaching file from URL.
            mm.Attachments.Add(new Attachment(stream, Path.GetFileName(apiUrl)));
            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.Host = host!;
                smtp.Port = port;
                smtp.EnableSsl = enableSsl;
                smtp.UseDefaultCredentials = defaultCredentials;
                NetworkCredential networkCred = new NetworkCredential(model.Email, model.Password);
                smtp.Credentials = networkCred;
                smtp.Send(mm);
            }
        }
        ViewData["Message"] = "Email sent.";
    }
}
