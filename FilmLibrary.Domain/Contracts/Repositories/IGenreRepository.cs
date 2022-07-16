using FilmLibrary.Domain.Entities;
using FilmLibrary.Domain.Helper;

namespace FilmLibrary.Domain.Contracts.Repositories;

public interface IGenreRepository
{
    Task<ICollection<Genre>> GetAllAsync();
    Task<ICollection<Genre>> GetMultipleAsync(IEnumerable<Guid> genreIds);
    Task<PaginatedResult<Genre>> GetPaginatedAsync(int offset, int count);
    Task<PaginatedResult<Genre>> PaginatedSearchAsync(string searchString, int offset, int count);
    Task<Genre?> GetAsync(Guid genreId);
    void Create(Genre genre);
    void Delete(Genre genre);
    Task SaveAsync();
}
