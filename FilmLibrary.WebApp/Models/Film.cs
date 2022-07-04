using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace FilmLibrary.WebApp.Models;

[DebuggerDisplay("Title: {Title}")]
public class Film
{
    [Required(ErrorMessage = "El título es requerido.")]
    [MaxLength(100)]
    public string Title { get; set; } = "";

    [Required(ErrorMessage = "El año es requerido.")]
    public int Year { get; set; }

    [Required(ErrorMessage = "El director es requerido.")]
    public Guid? DirectorId { get; set; }

    [Required(ErrorMessage = "El argumento de la película es requierido.")]
    [MaxLength(255)]
    public string Plot { get; set; } = "";

    [Required(ErrorMessage = "La clasificación es requerida.")]
    public Guid? RatingId { get; set; }

    [Required(ErrorMessage = "La fecha de estreno es requerida.")]
    public DateTime ReleaseDate { get; set; }

    [Required(ErrorMessage = "El país de origen es requerido.")]
    public Guid? CountryOfOriginId { get; set; }
}
