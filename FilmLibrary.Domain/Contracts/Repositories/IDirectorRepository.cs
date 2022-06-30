using FilmLibrary.Domain.Entities;

namespace FilmLibrary.Domain.Contracts.Repositories;

public interface IDirectorRepository
{
    Task<IEnumerable<Director>> GetAllAsync();
    Task<Director?> GetAsync(Guid directorId);
    void Create(Director director);
    void Delete(Director director);
    Task SaveAsync();
}
