using FilmLibrary.DataRepository;
using FilmLibrary.Domain.Contracts.Repositories;
using FilmLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmLibrary.Implementation.Repositories;

public class DirectorRepository : IDirectorRepository
{
    private readonly FilmLibraryDbContext _dbContext;

    public DirectorRepository(FilmLibraryDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IEnumerable<Director>> GetAllAsync()
    {
        return await _dbContext.Directors.ToListAsync();
    }

    public async Task<Director?> GetAsync(Guid directorId)
    {
        return await _dbContext.Directors.FindAsync(directorId);
    }

    public void Create(Director director)
    {
        _dbContext.Directors.Add(director);
    }

    public void Delete(Director director)
    {
        _dbContext.Directors.Remove(director);
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
