using FilmLibrary.DataRepository;
using FilmLibrary.Domain.Contracts.Repositories;
using FilmLibrary.Domain.Entities;
using FilmLibrary.Domain.Helper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FilmLibrary.Implementation.Repositories;

public class FilmRepository : IFilmRepository
{
    private readonly FilmLibraryDbContext _dbContext;

    public FilmRepository(FilmLibraryDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IEnumerable<Film>> GetAllAsync()
    {
        return await _dbContext.Films
            .Include(film => film.Director)
            .Include(film => film.CountryOfOrigin)
            .Include(film => film.Rating)
            .Include(film => film.Genres)
            .OrderBy(f => f.Title)
            .ToListAsync();
    }

    public async Task<PaginatedResult<Film>> GetPaginatedAsync(int offset, int count)
    {
        var list = await _dbContext.Films
            .Include(film => film.Director)
            .Include(film => film.CountryOfOrigin)
            .Include(film => film.Rating)
            .Include(film => film.Genres)
            .OrderBy(c => c.Title)
            .Skip(count * (offset - 1))
            .Take(count)
            .ToListAsync();

        var totalItems = await _dbContext.Films.CountAsync();

        var pagination = new PaginatedResult<Film>
        {
            CurrentPage = offset,
            PageSize = count,
            ItemCount = list.Count,
            TotalItems = totalItems,
            TotalPages = totalItems / count + 1,
            Collection = list
        };

        return pagination;
    }

    public async Task<PaginatedResult<Film>> PaginatedSearchAsync(string searchString, int offset, int count)
    {
        var list = await _dbContext.Films
            .Where(f => f.Title.Contains(searchString))
            .OrderBy(f => f.Title)
            .Skip(count * (offset - 1))
            .Take(count)
            .ToListAsync();

        var totalItems = await _dbContext.Films
            .Where(f => f.Title.Contains(searchString))
            .CountAsync();

        var paginatedResult = new PaginatedResult<Film>
        {
            CurrentPage = offset,
            PageSize = count,
            ItemCount = list.Count,
            TotalItems = totalItems,
            TotalPages = totalItems / count + 1,
            Collection = list
        };

        return paginatedResult;
    }

    public async Task<Film?> GetAsync(Guid filmId)
    {
        return await _dbContext.Films
            .Include(film => film.Director)
            .Include(film => film.CountryOfOrigin)
            .Include(film => film.Rating)
            .Include(film => film.Genres)
            .FirstOrDefaultAsync(film => film.Id == filmId);
    }

    public void Create(Film film)
    {
        _dbContext.Films.Add(film);
    }

    public void Delete(Film film)
    {
        _dbContext.Films.Remove(film);
    }

    public async Task<bool> SaveAsync()
    {
        try
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
        catch (Exception e) when (e is SqlException || e is DbUpdateException)
        {
        }

        return false;
    }
}
