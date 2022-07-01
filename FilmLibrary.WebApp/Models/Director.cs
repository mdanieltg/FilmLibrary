using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace FilmLibrary.WebApp.Models;

[DebuggerDisplay("Name: {Name}")]
public class Director
{
    [Required]
    [MaxLength(255)]
    public string Name { get; set; } = "";
}
