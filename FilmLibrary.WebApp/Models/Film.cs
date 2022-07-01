using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace FilmLibrary.WebApp.Models;

[DebuggerDisplay("Title: {Title}")]
public class Film
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = "";

    public int Year { get; set; }
    public Guid DirectorId { get; set; }

    [Required]
    [MaxLength(255)]
    public string Plot { get; set; } = "";

    public Guid RatingId { get; set; }
    public DateTime ReleaseDate { get; set; }
    public Guid CountryOfOriginId { get; set; }
}
