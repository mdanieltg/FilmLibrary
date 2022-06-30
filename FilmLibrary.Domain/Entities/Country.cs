using System.Diagnostics;

namespace FilmLibrary.Domain.Entities;

[DebuggerDisplay("Name: {Name}")]
public class Country
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    
    public ICollection<Film> Films { get; set; } = new HashSet<Film>();
}
