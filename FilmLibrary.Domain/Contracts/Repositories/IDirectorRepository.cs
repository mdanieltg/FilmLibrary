using FilmLibrary.Domain.Entities;
using FilmLibrary.Domain.Helper;

namespace FilmLibrary.Domain.Contracts.Repositories;

public interface IDirectorRepository
{
    Task<IEnumerable<Director>> GetAllAsync();
    Task<PaginatedResult<Director>> GetPaginatedAsync(int offset, int count);
    Task<PaginatedResult<Director>> PaginatedSearchAsync(string searchString, int offset, int count);
    Task<Director?> GetAsync(Guid directorId);
    void Create(Director director);
    void Delete(Director director);
    Task SaveAsync();
}
