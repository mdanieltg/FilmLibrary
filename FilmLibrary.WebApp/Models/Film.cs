using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace FilmLibrary.WebApp.Models;

[DebuggerDisplay("Title: {Title}")]
public class Film
{
    [Required(ErrorMessage = "El título es requerido.")]
    [MaxLength(100, ErrorMessage = "La longitud del título no puede ser mayor a 100 caracteres.")]
    public string Title { get; set; } = "";

    [Required(ErrorMessage = "El año es requerido.")]
    public int? Year { get; set; }

    [Required(ErrorMessage = "El director es requerido.")]
    public Guid? DirectorId { get; set; }

    [Required(ErrorMessage = "El argumento de la película es requerido.")]
    [MaxLength(255, ErrorMessage = "La longitud del argumento de la película no puede ser mayor a 255 caracteres.")]
    public string Plot { get; set; } = "";

    [Required(ErrorMessage = "La clasificación es requerida.")]
    public Guid? RatingId { get; set; }

    [Required(ErrorMessage = "La fecha de estreno es requerida.")]
    public DateTime? ReleaseDate { get; set; }

    [Required(ErrorMessage = "El país de origen es requerido.")]
    public Guid? CountryOfOriginId { get; set; }

    [Required(ErrorMessage = "Es necesario elegir al menos un género.")]
    [MinLength(1, ErrorMessage = "Es necesario elegir al menos un género.")]
    public ICollection<Guid> GenreIds { get; set; } = new List<Guid>();
}
