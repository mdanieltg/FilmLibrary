namespace FilmLibrary.Domain.Helper;

public class Pagination<T>
{
    public int Total { get; set; }
    public int Offset { get; set; }
    public int Count { get; set; }
    public IEnumerable<T> Collection { get; set; } = null!;
}
