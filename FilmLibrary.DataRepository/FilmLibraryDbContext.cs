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
            builder.HasIndex(f => f.Title)
                .IsUnique();
            builder.Property(f => f.Title)
                .HasMaxLength(100);
            builder.Property(f => f.Plot)
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Director>(builder =>
        {
            builder.HasIndex(d => d.Name)
                .IsUnique();
            builder.Property(d => d.Name)
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Country>(builder =>
        {
            builder.HasIndex(c => c.Name)
                .IsUnique();
            builder.Property(c => c.Name)
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Genre>(builder =>
        {
            builder.HasIndex(g => g.Name)
                .IsUnique();
            builder.Property(g => g.Name)
                .HasMaxLength(255);
            builder.HasData(
                new Genre { Id = Guid.Parse("34dd8660-b7da-4626-cc71-08da5b7b0adb"), Name = "Acción" },
                new Genre { Id = Guid.Parse("35b924df-d199-45a5-cc6d-08da5b7b0adb"), Name = "Ciencia ficción" },
                new Genre { Id = Guid.Parse("441b397f-7af0-46ca-ffa7-08da5c884309"), Name = "Comedia" },
                new Genre { Id = Guid.Parse("1e7ec66d-6114-4710-ffa8-08da5c884309"), Name = "Crimen" },
                new Genre { Id = Guid.Parse("ffe8aac7-2fd7-4ef1-ffa6-08da5c884309"), Name = "Documental" },
                new Genre { Id = Guid.Parse("4ea80f53-593c-4636-cc6f-08da5b7b0adb"), Name = "Drama" },
                new Genre { Id = Guid.Parse("c1c843db-ad47-4d0b-cc6c-08da5b7b0adb"), Name = "Fantasía" },
                new Genre { Id = Guid.Parse("0ef4d820-96f4-476b-ffa9-08da5c884309"), Name = "Musical" },
                new Genre { Id = Guid.Parse("4dd12164-0e2c-4d55-cc70-08da5b7b0adb"), Name = "Romance" },
                new Genre { Id = Guid.Parse("ed8c8d63-416b-452d-cc6e-08da5b7b0adb"), Name = "Suspenso" },
                new Genre { Id = Guid.Parse("0489f31a-b9a7-4160-ffa5-08da5c884309"), Name = "Terror" },
                new Genre { Id = Guid.Parse("10cb7746-bec4-4e24-ffaa-08da5c884309"), Name = "Western" }
            );
        });

        modelBuilder.Entity<Rating>(builder =>
        {
            builder.HasIndex(r => r.Name)
                .IsUnique();
            builder.Property(r => r.Name)
                .HasMaxLength(20);
            builder.Property(r => r.Description)
                .HasMaxLength(255);
            builder.HasData(
                new Rating { Id = Guid.Parse("22c977a8-683f-43e5-97ed-e411e9a0568b"), Name = "G", Description = "General audiences – All ages admitted" },
                new Rating { Id = Guid.Parse("9903c142-6474-432e-97d4-5b66bd6a18c2"), Name = "PG", Description = "Parental guidance suggested – Some material may not be suitable for children" },
                new Rating { Id = Guid.Parse("9e714ed4-a1a3-4e62-b49d-856b3009d528"), Name = "PG-13", Description = "Parents strongly cautioned – Some material may be inappropriate for children under 13" },
                new Rating { Id = Guid.Parse("a4a5eb16-c029-4ae6-ae0a-f56bab161d7d"), Name = "R", Description = "Restricted – Under 17 requires accompanying parent or adult guardian" },
                new Rating { Id = Guid.Parse("bf9c6f50-b7c2-4e2d-97fb-bd318a3977f3"), Name = "NC-17", Description = "Adults only – No one 17 and under admitted" }
            );
        });

        base.OnModelCreating(modelBuilder);
    }
}
