using FilmLibrary.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmLibrary.WebApp.Components;

public class RegistriesCountViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(int itemCount, int totalItems)
    {
        return View(new RegistriesCountModel { ItemCount = itemCount, TotalItems = totalItems });
    }
}
