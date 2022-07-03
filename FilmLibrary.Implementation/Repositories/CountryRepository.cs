using FilmLibrary.DataRepository;
using FilmLibrary.Domain.Contracts.Repositories;
using FilmLibrary.Domain.Entities;
using FilmLibrary.Domain.Helper;
using Microsoft.EntityFrameworkCore;

namespace FilmLibrary.Implementation.Repositories;

public class CountryRepository : ICountryRepository
{
    private readonly FilmLibraryDbContext _dbContext;

    public CountryRepository(FilmLibraryDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IEnumerable<Country>> GetAllAsync()
    {
        return await _dbContext.Countries
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    public async Task<Pagination<Country>> GetPaginatedAsync(int offset, int count)
    {
        var list = await _dbContext.Countries
            .OrderBy(c => c.Name)
            .Skip(count * (offset - 1))
            .Take(count)
            .ToListAsync();

        var pagination = new Pagination<Country>
        {
            Offset = offset,
            Count = count,
            Total = list.Count,
            Collection = list
        };

        return pagination;
    }

    public Task<Country?> GetAsync(Guid countryId)
    {
        return _dbContext.Countries.FirstOrDefaultAsync(c => c.Id == countryId);
    }

    public void Create(Country country)
    {
        country.Id = Guid.NewGuid();
        _dbContext.Countries.Add(country);
    }

    public void Delete(Country country)
    {
        _dbContext.Countries.Remove(country);
    }

    public Task SaveAsync()
    {
        return _dbContext.SaveChangesAsync();
    }
}
