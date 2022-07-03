using FilmLibrary.Domain.Entities;
using FilmLibrary.Domain.Helper;

namespace FilmLibrary.Domain.Contracts.Repositories;

public interface IFilmRepository
{
    Task<IEnumerable<Film>> GetAllAsync();
    Task<Pagination<Film>> GetPaginatedAsync(int offset, int count);
    Task<Film?> GetAsync(Guid filmId);
    void Create(Film film);
    void Delete(Film film);
    Task<bool> SaveAsync();
}
