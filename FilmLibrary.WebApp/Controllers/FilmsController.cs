using FilmLibrary.Domain.Contracts.Repositories;
using FilmLibrary.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmLibrary.WebApp.Controllers;

[Route("/films")]
public class FilmsController : Controller
{
    private readonly ILogger<FilmsController> _logger;
    private readonly IFilmRepository _filmRepository;
    private readonly IDirectorRepository _directorRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IRatingRepository _ratingRepository;

    public FilmsController(ILogger<FilmsController> logger, IFilmRepository filmRepository,
        IDirectorRepository directorRepository, ICountryRepository countryRepository,
        IGenreRepository genreRepository, IRatingRepository ratingRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _filmRepository = filmRepository ?? throw new ArgumentNullException(nameof(filmRepository));
        _directorRepository = directorRepository ?? throw new ArgumentNullException(nameof(directorRepository));
        _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
        _genreRepository = genreRepository ?? throw new ArgumentNullException(nameof(genreRepository));
        _ratingRepository = ratingRepository ?? throw new ArgumentNullException(nameof(ratingRepository));
    }

    public async Task<ActionResult> Index(string search, Pagination pagination)
    {
        if (string.IsNullOrEmpty(search))
        {
            var paginated = await _filmRepository.GetPaginatedAsync(pagination.Page, pagination.Count);
            return View(paginated);
        }
        else
        {
            var paginatedSearchResult = await _filmRepository.PaginatedSearchAsync(search, pagination.Page,
                pagination.Count);
            ViewBag.SearchString = search;
            return View(paginatedSearchResult);
        }
    }

    [HttpGet("add")]
    public async Task<ActionResult> Add()
    {
        ViewBag.Directors = await _directorRepository.GetAllAsync();
        ViewBag.Countries = await _countryRepository.GetAllAsync();
        ViewBag.Ratings = await _ratingRepository.GetAllAsync();
        ViewBag.Genres = await _genreRepository.GetAllAsync();
        return View();
    }

    [HttpPost("add")]
    public async Task<ActionResult> Add(Film film)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Directors = await _directorRepository.GetAllAsync();
            ViewBag.Countries = await _countryRepository.GetAllAsync();
            ViewBag.Ratings = await _ratingRepository.GetAllAsync();
            ViewBag.Genres = await _genreRepository.GetAllAsync();
            return View(film);
        }

        var genres = await _genreRepository.GetMultipleAsync(film.GenreIds);

        _filmRepository.Create(new Domain.Entities.Film
        {
            Title = film.Title,
            Year = film.Year!.Value,
            DirectorId = film.DirectorId!.Value,
            Plot = film.Plot,
            RatingId = film.RatingId!.Value,
            ReleaseDate = film.ReleaseDate!.Value,
            CountryOfOriginId = film.CountryOfOriginId!.Value,
            Genres = genres
        });
        await _filmRepository.SaveAsync();

        return RedirectToAction("Index");
    }

    [HttpGet("details/{filmId}")]
    public async Task<ActionResult> Details(Guid filmId)
    {
        var film = await _filmRepository.GetAsync(filmId);
        if (film is null)
        {
            return RedirectToAction("Index");
        }

        return View(film);
    }

    [HttpGet("edit/{filmId}")]
    public async Task<ActionResult> Edit(Guid filmId)
    {
        var film = await _filmRepository.GetAsync(filmId);
        if (film is null)
        {
            return RedirectToAction("Index");
        }

        ViewBag.Directors = await _directorRepository.GetAllAsync();
        ViewBag.Countries = await _countryRepository.GetAllAsync();
        ViewBag.Ratings = await _ratingRepository.GetAllAsync();
        ViewBag.Genres = await _genreRepository.GetAllAsync();

        return View(new Film
        {
            Title = film.Title,
            Year = film.Year,
            DirectorId = film.DirectorId,
            Plot = film.Plot,
            RatingId = film.RatingId,
            ReleaseDate = film.ReleaseDate,
            CountryOfOriginId = film.CountryOfOriginId,
            GenreIds = film.Genres.Select(g => g.Id).ToList()
        });
    }

    [HttpPost("edit/{filmId}")]
    public async Task<ActionResult> Edit(Guid filmId, Film film)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Directors = await _directorRepository.GetAllAsync();
            ViewBag.Countries = await _countryRepository.GetAllAsync();
            ViewBag.Ratings = await _ratingRepository.GetAllAsync();
            ViewBag.Genres = await _genreRepository.GetAllAsync();
            return View(film);
        }

        var genres = await _genreRepository.GetMultipleAsync(film.GenreIds);
        var currentFilm = await _filmRepository.GetAsync(filmId);
        if (currentFilm is not null)
        {
            currentFilm.Title = film.Title;
            currentFilm.Year = film.Year!.Value;
            currentFilm.DirectorId = film.DirectorId!.Value;
            currentFilm.Plot = film.Plot;
            currentFilm.RatingId = film.RatingId!.Value;
            currentFilm.ReleaseDate = film.ReleaseDate!.Value;
            currentFilm.CountryOfOriginId = film.CountryOfOriginId!.Value;
            currentFilm.Genres = genres;
            await _filmRepository.SaveAsync();
        }

        return RedirectToAction("Index");
    }

    [HttpGet("delete/{filmId}")]
    public async Task<ActionResult> Delete(Guid filmId)
    {
        var film = await _filmRepository.GetAsync(filmId);
        if (film is null)
        {
            return RedirectToAction("Index");
        }

        return View(film);
    }

    [HttpPost("delete/{Id}")]
    public async Task<ActionResult> Delete(Domain.Entities.Film film)
    {
        var filmToDelete = await _filmRepository.GetAsync(film.Id);
        if (filmToDelete is null)
        {
            return RedirectToAction("Index");
        }

        _filmRepository.Delete(filmToDelete);
        await _filmRepository.SaveAsync();

        return RedirectToAction("Index");
    }
}
