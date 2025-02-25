using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetRazorPages.Models;

[Table("movies")]
public class Movie
{
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }
    public string? Actors { get; set; }
}
