using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace FilmLibrary.WebApp.Models;

[DebuggerDisplay("Name: {Name}")]
public class Genre
{
    [Required(ErrorMessage = "El nombre es requerido.")]
    [MaxLength(255)]
    public string Name { get; set; } = "";
}
