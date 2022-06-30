using FilmLibrary.DataRepository;
using FilmLibrary.Domain.Contracts.Repositories;
using FilmLibrary.Domain.Entities;
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
            .Include(film => film.Genres)
            .Include(film => film.CountryOfOrigin)
            .Include(film => film.Rating)
            .ToListAsync();
    }

    public async Task<Film?> GetAsync(Guid filmId)
    {
        return await _dbContext.Films
            .Include(film => film.Director)
            .Include(film => film.Genres)
            .Include(film => film.CountryOfOrigin)
            .Include(film => film.Rating)
            .FirstOrDefaultAsync(film => film.Id == filmId);
    }

    public void Create(Film film)
    {
        if (_dbContext.Directors.Find(film.DirectorId) is null)
        {
            throw new ArgumentException($"A director with Id {film.DirectorId} was not found.", nameof(film));
        }

        if (_dbContext.Directors.Find(film.CountryOfOriginId) is null)
        {
            throw new ArgumentException($"A director with Id {film.DirectorId} was not found.", nameof(film));
        }

        if (_dbContext.Directors.Find(film.RatingId) is null)
        {
            throw new ArgumentException($"A director with Id {film.DirectorId} was not found.", nameof(film));
        }

        _dbContext.Films.Add(film);
    }

    public void Delete(Film film)
    {
        _dbContext.Films.Remove(film);
    }

    public Task SaveAsync()
    {
        return _dbContext.SaveChangesAsync();
    }
}
