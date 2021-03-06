using FilmLibrary.Domain.Entities;
using FilmLibrary.Domain.Helper;

namespace FilmLibrary.Domain.Contracts.Repositories;

public interface ICountryRepository
{
    Task<ICollection<Country>> GetAllAsync();
    Task<PaginatedResult<Country>> GetPaginatedAsync(int offset, int count);
    Task<PaginatedResult<Country>> PaginatedSearchAsync(string searchString, int offset, int count);
    Task<Country?> GetAsync(Guid countryId);
    void Create(Country country);
    void Delete(Country country);
    Task SaveAsync();
}
