using System.Diagnostics;

namespace FilmLibrary.Domain.Entities;

[DebuggerDisplay("Name: {Title}")]
public class Film
{
    public Guid Id { get; set; }
    public string Title { get; set; } = "";
    public int Year { get; set; }
    public Guid DirectorId { get; set; }
    public string Plot { get; set; } = "";
    public Guid RatingId { get; set; }
    public DateTime ReleaseDate { get; set; }
    public Guid CountryOfOriginId { get; set; }

    public ICollection<Genre> Genres { get; set; } = new HashSet<Genre>();
    public Director? Director { get; set; }
    public Rating? Rating { get; set; }
    public Country? CountryOfOrigin { get; set; }
}
