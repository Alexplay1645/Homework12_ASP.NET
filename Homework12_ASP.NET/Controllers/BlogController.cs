using Homework12_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

public class BlogController : Controller
{
    private static List<News> _news = new()
    {
        new News { Id = 1, Title = "Первая новость", Content = "Контент первой новости", PublishedAt = DateTime.Now },
        new News { Id = 2, Title = "Вторая новость", Content = "Контент второй новости", PublishedAt = DateTime.Now }
    };

    public IActionResult Index()
    {
        string theme = Request.Cookies["theme"] ?? "light";
        ViewBag.Theme = theme;

        return View(_news);
    }

    [HttpGet]
    public IActionResult Settings()
    {
        string theme = Request.Cookies["theme"] ?? "light";
        ViewBag.Theme = theme;
        return View();
    }

    [HttpPost]
    public IActionResult Settings(string theme)
    {
        Response.Cookies.Append("theme", theme, new CookieOptions
        {
            Expires = DateTime.Now.AddDays(7)
        });

        return RedirectToAction("Index");
    }
}
