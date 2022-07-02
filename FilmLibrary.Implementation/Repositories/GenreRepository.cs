using FilmLibrary.DataRepository;
using FilmLibrary.Domain.Contracts.Repositories;
using FilmLibrary.Domain.Entities;
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
