using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetRazorPages.Models;

[Table("actors")]
public class Actor
{
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }
}
