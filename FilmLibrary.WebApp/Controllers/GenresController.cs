using FilmLibrary.Domain.Contracts.Repositories;
using FilmLibrary.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmLibrary.WebApp.Controllers;

[Route("/genres")]
public class GenresController : Controller
{
    private readonly ILogger<GenresController> _logger;
    private readonly IGenreRepository _genreRepository;

    public GenresController(ILogger<GenresController> logger, IGenreRepository genreRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _genreRepository = genreRepository ?? throw new ArgumentNullException(nameof(genreRepository));
    }

    public async Task<ActionResult> Index()
    {
        var genres = await _genreRepository.GetAllAsync();
        return View(genres);
    }

    [HttpGet("add")]
    public ActionResult Add()
    {
        return View();
    }

    [HttpPost("add")]
    public async Task<ActionResult> Add(Genre genre)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        _genreRepository.Create(new Domain.Entities.Genre { Name = genre.Name });
        await _genreRepository.SaveAsync();

        return RedirectToAction("Index");
    }

    [HttpGet("details/{genreId}")]
    public async Task<ActionResult> Details(Guid genreId)
    {
        var genre = await _genreRepository.GetAsync(genreId);
        if (genre is null)
        {
            return RedirectToAction("Index");
        }

        return View(genre);
    }

    [HttpGet("edit/{genreId}")]
    public async Task<ActionResult> Edit(Guid genreId)
    {
        var genre = await _genreRepository.GetAsync(genreId);
        if (genre is null)
        {
            return RedirectToAction("Index");
        }

        return View(new Genre { Name = genre.Name });
    }

    [HttpPost("edit/{genreId}")]
    public async Task<ActionResult> Edit(Guid genreId, Genre genre)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var currentGenre = await _genreRepository.GetAsync(genreId);
        if (currentGenre is not null)
        {
            currentGenre.Name = genre.Name;
            await _genreRepository.SaveAsync();
        }

        return RedirectToAction("Index");
    }

    [HttpGet("delete/{genreId}")]
    public async Task<ActionResult> Delete(Guid genreId)
    {
        var genre = await _genreRepository.GetAsync(genreId);
        if (genre is null)
        {
            return RedirectToAction("Index");
        }

        return View(genre);
    }

    [HttpPost("delete/{Id}")]
    public async Task<ActionResult> Delete(Domain.Entities.Genre genre)
    {
        var genreToDelete = await _genreRepository.GetAsync(genre.Id);
        if (genreToDelete is null)
        {
            return RedirectToAction("Index");
        }

        _genreRepository.Delete(genreToDelete);
        await _genreRepository.SaveAsync();

        return RedirectToAction("Index");
    }
}
