using FilmLibrary.Domain.Entities;

namespace FilmLibrary.Domain.Contracts.Repositories;

public interface ICountryRepository
{
    Task<IEnumerable<Country>> GetAllAsync();
    Task<Country?> GetAsync(Guid countryId);
    void Create(Country country);
    void Delete(Country country);
    Task SaveAsync();
}
