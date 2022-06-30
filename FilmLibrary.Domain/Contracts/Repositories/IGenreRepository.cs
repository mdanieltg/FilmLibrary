using FilmLibrary.Domain.Entities;

namespace FilmLibrary.Domain.Contracts.Repositories;

public interface IGenreRepository
{
    Task<IEnumerable<Genre>> GetAllAsync();
    Task<Genre?> GetAsync(Guid genreId);
    void Create(Genre genre);
    void Delete(Genre genre);
    Task SaveAsync();
}
