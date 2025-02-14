using System.Net;
using System.Net.Mail;

namespace DotNetRazorPages.Models;

public class EmailModel
{
    public required string To { get; set; }
    public required string Subject { get; set; }
    public required string Body { get; set; }
    public required bool IsBodyHtml { get; set; }
    public Attachment? Attachment { get; set; }

    public void SendEmail(IConfiguration configuration)
    {
        //Read SMTP section from AppSettings.json.
        string? host = configuration.GetValue<string>("Smtp:Server");
        int port = configuration.GetValue<int>("Smtp:Port");
        bool enableSsl = configuration.GetValue<bool>("Smtp:EnableSsl");
        bool defaultCredentials = configuration.GetValue<bool>("Smtp:DefaultCredentials");

        #region MailerSend secret
        string username = Environment.GetEnvironmentVariable("MAILERSEND_USERNAME") ?? string.Empty;
        string password = Environment.GetEnvironmentVariable("MAILERSEND_PASSWORD") ?? string.Empty;
        #endregion

        using MailMessage mm = new(username, To);
        mm.Subject = Subject;
        mm.Body = Body;
        mm.IsBodyHtml = IsBodyHtml;

        //Attaching file from URL.
        if (Attachment != null)
        {
            mm.Attachments.Add(Attachment);
        }
        using SmtpClient smtp = new();
        smtp.Host = host!;
        smtp.Port = port;
        smtp.EnableSsl = enableSsl;
        smtp.UseDefaultCredentials = defaultCredentials;

        NetworkCredential networkCred = new(username, password);
        smtp.Credentials = networkCred;
        smtp.Send(mm);
    }
}
