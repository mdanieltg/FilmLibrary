using FilmLibrary.Domain.Entities;

namespace FilmLibrary.Domain.Contracts.Repositories;

public interface IFilmRepository
{
    Task<IEnumerable<Film>> GetAllAsync();
    Task<Film?> GetAsync(Guid filmId);
    void Create(Film film);
    void Delete(Film film);
    Task SaveAsync();
}
