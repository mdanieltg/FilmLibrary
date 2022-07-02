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

    public async Task<ActionResult> Index()
    {
        var films = await _filmRepository.GetAllAsync();
        return View(films);
    }

    [HttpGet("add")]
    public async Task<ActionResult> Add()
    {
        ViewBag.Directors = await _directorRepository.GetAllAsync();
        ViewBag.Countries = await _countryRepository.GetAllAsync();
        ViewBag.Ratings = await _ratingRepository.GetAllAsync();
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
            return View();
        }

        _filmRepository.Create(new Domain.Entities.Film
        {
            Title = film.Title,
            Year = film.Year,
            DirectorId = film.DirectorId,
            Plot = film.Plot,
            RatingId = film.RatingId,
            ReleaseDate = film.ReleaseDate,
            CountryOfOriginId = film.CountryOfOriginId
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

        return View(new Film
        {
            Title = film.Title,
            Year = film.Year,
            DirectorId = film.DirectorId,
            Plot = film.Plot,
            RatingId = film.RatingId,
            ReleaseDate = film.ReleaseDate,
            CountryOfOriginId = film.CountryOfOriginId
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
            return View();
        }

        var currentFilm = await _filmRepository.GetAsync(filmId);
        if (currentFilm is not null)
        {
            currentFilm.Title = film.Title;
            currentFilm.Year = film.Year;
            currentFilm.DirectorId = film.DirectorId;
            currentFilm.Plot = film.Plot;
            currentFilm.RatingId = film.RatingId;
            currentFilm.ReleaseDate = film.ReleaseDate;
            currentFilm.CountryOfOriginId = film.CountryOfOriginId;
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
