using FilmLibrary.Domain.Contracts.Repositories;
using FilmLibrary.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmLibrary.WebApp.Controllers;

[Route("/directors")]
public class DirectorsController : Controller
{
    private readonly ILogger<DirectorsController> _logger;
    private readonly IDirectorRepository _directorRepository;

    public DirectorsController(ILogger<DirectorsController> logger, IDirectorRepository directorRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _directorRepository = directorRepository ?? throw new ArgumentNullException(nameof(directorRepository));
    }

    public async Task<ActionResult> Index(Pagination pagination)
    {
        var paginated = await _directorRepository.GetPaginatedAsync(pagination.Page, pagination.Count);
        return View(paginated);
    }

    [HttpGet("add")]
    public ActionResult Add()
    {
        return View();
    }

    [HttpPost("add")]
    public async Task<ActionResult> Add(Director director)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        _directorRepository.Create(new Domain.Entities.Director { Name = director.Name });
        await _directorRepository.SaveAsync();

        return RedirectToAction("Index");
    }

    [HttpGet("details/{directorId}")]
    public async Task<ActionResult> Details(Guid directorId)
    {
        var director = await _directorRepository.GetAsync(directorId);
        if (director is null)
        {
            return RedirectToAction("Index");
        }

        return View(director);
    }

    [HttpGet("edit/{directorId}")]
    public async Task<ActionResult> Edit(Guid directorId)
    {
        var director = await _directorRepository.GetAsync(directorId);
        if (director is null)
        {
            return RedirectToAction("Index");
        }

        return View(new Director { Name = director.Name });
    }

    [HttpPost("edit/{directorId}")]
    public async Task<ActionResult> Edit(Guid directorId, Director director)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var currentDirector = await _directorRepository.GetAsync(directorId);
        if (currentDirector is not null)
        {
            currentDirector.Name = director.Name;
            await _directorRepository.SaveAsync();
        }

        return RedirectToAction("Index");
    }

    [HttpGet("delete/{directorId}")]
    public async Task<ActionResult> Delete(Guid directorId)
    {
        var director = await _directorRepository.GetAsync(directorId);
        if (director is null)
        {
            return RedirectToAction("Index");
        }

        return View(director);
    }

    [HttpPost("delete/{Id}")]
    public async Task<ActionResult> Delete(Domain.Entities.Director director)
    {
        var directorToDelete = await _directorRepository.GetAsync(director.Id);
        if (directorToDelete is null)
        {
            return RedirectToAction("Index");
        }

        _directorRepository.Delete(directorToDelete);
        await _directorRepository.SaveAsync();

        return RedirectToAction("Index");
    }
}
