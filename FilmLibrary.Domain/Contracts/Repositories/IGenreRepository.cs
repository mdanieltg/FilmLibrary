using FilmLibrary.Domain.Entities;
using FilmLibrary.Domain.Helper;

namespace FilmLibrary.Domain.Contracts.Repositories;

public interface IGenreRepository
{
    Task<IEnumerable<Genre>> GetAllAsync();
    Task<PaginatedResult<Genre>> GetPaginatedAsync(int offset, int count);
    Task<Genre?> GetAsync(Guid genreId);
    void Create(Genre genre);
    void Delete(Genre genre);
    Task SaveAsync();
}
