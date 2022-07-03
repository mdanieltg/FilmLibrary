using FilmLibrary.Domain.Contracts.Repositories;
using FilmLibrary.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmLibrary.WebApp.Controllers;

[Route("/countries")]
public class CountriesController : Controller
{
    private readonly ILogger<CountriesController> _logger;
    private readonly ICountryRepository _countryRepository;

    public CountriesController(ILogger<CountriesController> logger, ICountryRepository countryRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
    }

    public async Task<ActionResult> Index(Pagination pagination)
    {
        var paginated = await _countryRepository.GetPaginatedAsync(pagination.Page, pagination.Count);
        return View(paginated);
    }

    [HttpGet("add")]
    public ActionResult Add()
    {
        return View();
    }

    [HttpPost("add")]
    public async Task<ActionResult> Add(Country country)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        _countryRepository.Create(new Domain.Entities.Country { Name = country.Name });
        await _countryRepository.SaveAsync();

        return RedirectToAction("Index");
    }

    [HttpGet("details/{countryId}")]
    public async Task<ActionResult> Details(Guid countryId)
    {
        var country = await _countryRepository.GetAsync(countryId);
        if (country is null)
        {
            return RedirectToAction("Index");
        }

        return View(country);
    }

    [HttpGet("edit/{countryId}")]
    public async Task<ActionResult> Edit(Guid countryId)
    {
        var country = await _countryRepository.GetAsync(countryId);
        if (country is null)
        {
            return RedirectToAction("Index");
        }

        return View(new Country { Name = country.Name });
    }

    [HttpPost("edit/{countryId}")]
    public async Task<ActionResult> Edit(Guid countryId, Country country)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var currentCountry = await _countryRepository.GetAsync(countryId);
        if (currentCountry is not null)
        {
            currentCountry.Name = country.Name;
            await _countryRepository.SaveAsync();
        }

        return RedirectToAction("Index");
    }

    [HttpGet("delete/{countryId}")]
    public async Task<ActionResult> Delete(Guid countryId)
    {
        var country = await _countryRepository.GetAsync(countryId);
        if (country is null)
        {
            return RedirectToAction("Index");
        }

        return View(country);
    }

    [HttpPost("delete/{Id}")]
    public async Task<ActionResult> Delete(Domain.Entities.Country country)
    {
        var countryToDelete = await _countryRepository.GetAsync(country.Id);
        if (countryToDelete is null)
        {
            return RedirectToAction("Index");
        }

        _countryRepository.Delete(countryToDelete);
        await _countryRepository.SaveAsync();

        return RedirectToAction("Index");
    }
}
