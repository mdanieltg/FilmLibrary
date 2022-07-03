using FilmLibrary.Domain.Entities;
using FilmLibrary.Domain.Helper;

namespace FilmLibrary.Domain.Contracts.Repositories;

public interface IDirectorRepository
{
    Task<IEnumerable<Director>> GetAllAsync();
    Task<Pagination<Director>> GetPaginatedAsync(int offset, int count);
    Task<Director?> GetAsync(Guid directorId);
    void Create(Director director);
    void Delete(Director director);
    Task SaveAsync();
}
