using FilmLibrary.DataRepository;
using FilmLibrary.Domain.Contracts.Repositories;
using FilmLibrary.Domain.Entities;
using FilmLibrary.Domain.Helper;
using Microsoft.EntityFrameworkCore;

namespace FilmLibrary.Implementation.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly FilmLibraryDbContext _dbContext;

    public GenreRepository(FilmLibraryDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IEnumerable<Genre>> GetAllAsync()
    {
        return await _dbContext.Genres
            .OrderBy(g => g.Name)
            .ToListAsync();
    }

    public async Task<PaginatedResult<Genre>> GetPaginatedAsync(int offset, int count)
    {
        var list = await _dbContext.Genres
            .OrderBy(c => c.Name)
            .Skip(count * (offset - 1))
            .Take(count)
            .ToListAsync();

        var totalItems = await _dbContext.Genres.CountAsync();

        var pagination = new PaginatedResult<Genre>
        {
            CurrentPage = offset,
            PageSize = count,
            ItemCount = list.Count,
            TotalItems = totalItems,
            TotalPages = totalItems % count == 0 ? totalItems / count : totalItems / count + 1,
            Collection = list
        };

        return pagination;
    }

    public async Task<PaginatedResult<Genre>> PaginatedSearchAsync(string searchString, int offset, int count)
    {
        var list = await _dbContext.Genres
            .Where(g => g.Name.Contains(searchString))
            .OrderBy(g => g.Name)
            .Skip(count * (offset - 1))
            .Take(count)
            .ToListAsync();

        var totalItems = await _dbContext.Genres
            .Where(g => g.Name.Contains(searchString))
            .CountAsync();

        var paginatedResult = new PaginatedResult<Genre>
        {
            CurrentPage = offset,
            PageSize = count,
            ItemCount = list.Count,
            TotalItems = totalItems,
            TotalPages = totalItems % count == 0 ? totalItems / count : totalItems / count + 1,
            Collection = list
        };

        return paginatedResult;
    }

    public async Task<Genre?> GetAsync(Guid genreId)
    {
        return await _dbContext.Genres.FindAsync(genreId);
    }

    public void Create(Genre genre)
    {
        _dbContext.Genres.Add(genre);
    }

    public void Delete(Genre genre)
    {
        _dbContext.Genres.Remove(genre);
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
