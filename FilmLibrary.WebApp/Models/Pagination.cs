namespace FilmLibrary.WebApp.Models;

public class Pagination
{
    private int _page;
    private int _count;

    public Pagination()
    {
        _page = 1;
        _count = 10;
    }

    public int Page
    {
        get => _page;
        set
        {
            _page = value switch
            {
                <= 0 => 1,
                _ => value
            };
        }
    }

    public int Count
    {
        get => _count;
        set
        {
            _count = value switch
            {
                <= 0 => 10,
                > 50 => 50,
                _ => value
            };
        }
    }
}
