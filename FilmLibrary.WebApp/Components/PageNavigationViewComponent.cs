using FilmLibrary.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmLibrary.WebApp.Components;

public class PageNavigationViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(int currentPage, int pageSize, int totalPages)
    {
        var pageNavigationModel = new PageNavigationModel
        {
            CurrentPage = currentPage,
            PageSize = pageSize,
            TotalPages = totalPages
        };
        return View(pageNavigationModel);
    }
}
