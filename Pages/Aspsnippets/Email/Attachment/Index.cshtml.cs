using System.Net;
using System.Net.Mail;
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
        //Read SMTP section from AppSettings.json.
        string? host = _configuration.GetValue<string>("Smtp:Server");
        int port = _configuration.GetValue<int>("Smtp:Port");
        bool enableSsl = _configuration.GetValue<bool>("Smtp:EnableSsl");
        bool defaultCredentials = _configuration.GetValue<bool>("Smtp:DefaultCredentials");

        #region MailerSend secret
        string username = Environment.GetEnvironmentVariable("MAILERSEND_USERNAME") ?? string.Empty;
        string password = Environment.GetEnvironmentVariable("MAILERSEND_PASSWORD") ?? string.Empty;
        #endregion

        using (MailMessage mm = new(username, emailModel.To))
        {
            mm.Subject = emailModel.Subject;
            mm.Body = emailModel.Body;
            mm.IsBodyHtml = false;

            //Attaching file from URL.
            mm.Attachments.Add(new System.Net.Mail.Attachment(stream, Path.GetFileName(apiUrl)));
            using SmtpClient smtp = new();
            smtp.Host = host!;
            smtp.Port = port;
            smtp.EnableSsl = enableSsl;
            smtp.UseDefaultCredentials = defaultCredentials;


            NetworkCredential networkCred = new(username, password);
            smtp.Credentials = networkCred;
            smtp.Send(mm);
        }
        ViewData["Message"] = "Email sent.";
    }
}
