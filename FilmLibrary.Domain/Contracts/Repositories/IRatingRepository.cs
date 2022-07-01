using FilmLibrary.Domain.Entities;

namespace FilmLibrary.Domain.Contracts.Repositories;

public interface IRatingRepository
{
    Task<IEnumerable<Rating>> GetAllAsync();
    Task<Rating?> GetAsync(Guid ratingId);
}
