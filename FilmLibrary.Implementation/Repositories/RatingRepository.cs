using FilmLibrary.DataRepository;
using FilmLibrary.Domain.Contracts.Repositories;
using FilmLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmLibrary.Implementation.Repositories;

public class RatingRepository : IRatingRepository
{
    private readonly FilmLibraryDbContext _dbContext;

    public RatingRepository(FilmLibraryDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IEnumerable<Rating>> GetAllAsync()
    {
        return await _dbContext.Ratings
            .OrderBy(r => r.Name)
            .ToListAsync();
    }

    public async Task<Rating?> GetAsync(Guid ratingId)
    {
        return await _dbContext.Ratings.FindAsync(ratingId);
    }
}
