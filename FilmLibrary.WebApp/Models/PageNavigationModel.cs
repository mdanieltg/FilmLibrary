namespace FilmLibrary.WebApp.Models;

public class PageNavigationModel
{
    public int CurrentPage { get; set; }
    public int? PreviousPage => CurrentPage <= 1 ? null : CurrentPage - 1;
    public int? NextPage => CurrentPage >= TotalPages ? null : CurrentPage + 1;
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
}
