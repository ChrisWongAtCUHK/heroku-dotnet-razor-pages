using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetRazorPages.Models;

[Table("customers")]
public class Customer
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string? Name { get; set; }
}
