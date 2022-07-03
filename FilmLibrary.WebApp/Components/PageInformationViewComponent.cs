using FilmLibrary.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmLibrary.WebApp.Components;

public class PageInformationViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(int currentPage, int totalPages)
    {
        return View(new PageInformationModel { CurrentPage = currentPage, TotalPages = totalPages });
    }
}
