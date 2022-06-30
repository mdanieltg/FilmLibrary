using FilmLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmLibrary.DataRepository;

public class FilmLibraryDbContext : DbContext
{
    public FilmLibraryDbContext()
    {
    }

    public FilmLibraryDbContext(DbContextOptions<FilmLibraryDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }

    public DbSet<Film> Films { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=FilmLibrary;Trusted_Connection=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Film>(builder =>
        {
            builder.Property(f => f.Title)
                .HasMaxLength(100);
            builder.Property(f => f.Plot)
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Director>()
            .Property(d => d.Name)
            .HasMaxLength(255);

        modelBuilder.Entity<Genre>()
            .Property(g => g.Name)
            .HasMaxLength(255);

        modelBuilder.Entity<Country>()
            .Property(c => c.Name)
            .HasMaxLength(255);

        modelBuilder.Entity<Rating>()
            .HasData(
                new Rating
                {
                    Id = Guid.Parse("22c977a8-683f-43e5-97ed-e411e9a0568b"),
                    Name = "G",
                    Description = "General audiences – All ages admitted"
                },
                new Rating
                {
                    Id = Guid.Parse("9903c142-6474-432e-97d4-5b66bd6a18c2"),
                    Name = "PG",
                    Description = "Parental guidance suggested – Some material may not be suitable for children"
                },
                new Rating
                {
                    Id = Guid.Parse("9e714ed4-a1a3-4e62-b49d-856b3009d528"),
                    Name = "PG-13",
                    Description = "Parents strongly cautioned – Some material may be inappropriate for children under 13"
                },
                new Rating
                {
                    Id = Guid.Parse("a4a5eb16-c029-4ae6-ae0a-f56bab161d7d"),
                    Name = "R",
                    Description = "Restricted – Under 17 requires accompanying parent or adult guardian"
                },
                new Rating
                {
                    Id = Guid.Parse("bf9c6f50-b7c2-4e2d-97fb-bd318a3977f3"),
                    Name = "NC-17",
                    Description = "Adults only – No one 17 and under admitted"
                }
            );

        base.OnModelCreating(modelBuilder);
    }
}
