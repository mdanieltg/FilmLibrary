namespace FilmLibrary.Domain.Helper;

public class PaginatedResult<T>
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public IEnumerable<T> Collection { get; set; } = null!;
}
