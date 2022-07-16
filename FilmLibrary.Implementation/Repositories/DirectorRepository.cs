using FilmLibrary.DataRepository;
using FilmLibrary.Domain.Contracts.Repositories;
using FilmLibrary.Domain.Entities;
using FilmLibrary.Domain.Helper;
using Microsoft.EntityFrameworkCore;

namespace FilmLibrary.Implementation.Repositories;

public class DirectorRepository : IDirectorRepository
{
    private readonly FilmLibraryDbContext _dbContext;

    public DirectorRepository(FilmLibraryDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<ICollection<Director>> GetAllAsync()
    {
        return await _dbContext.Directors
            .OrderBy(d => d.Name)
            .ToListAsync();
    }

    public async Task<PaginatedResult<Director>> GetPaginatedAsync(int offset, int count)
    {
        var list = await _dbContext.Directors
            .OrderBy(c => c.Name)
            .Skip(count * (offset - 1))
            .Take(count)
            .ToListAsync();

        var totalItems = await _dbContext.Directors.CountAsync();

        var pagination = new PaginatedResult<Director>
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

    public async Task<PaginatedResult<Director>> PaginatedSearchAsync(string searchString, int offset, int count)
    {
        var list = await _dbContext.Directors
            .Where(d => d.Name.Contains(searchString))
            .OrderBy(d => d.Name)
            .Skip(count * (offset - 1))
            .Take(count)
            .ToListAsync();

        var totalItems = await _dbContext.Directors
            .Where(d => d.Name.Contains(searchString))
            .CountAsync();

        var paginatedResult = new PaginatedResult<Director>
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

    public async Task<Director?> GetAsync(Guid directorId)
    {
        return await _dbContext.Directors.FindAsync(directorId);
    }

    public void Create(Director director)
    {
        _dbContext.Directors.Add(director);
    }

    public void Delete(Director director)
    {
        _dbContext.Directors.Remove(director);
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
