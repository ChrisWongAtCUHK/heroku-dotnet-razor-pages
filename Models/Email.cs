using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetRazorPages.Models;

public class EmailModel
{
    public required string To { get; set; }
    public required string Subject { get; set; }
    public required string Body { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}
