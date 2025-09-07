using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BadmintonCourts.Models;

namespace BadmintonCourts.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // GET: Homepage
    public IActionResult Index()
    {
        return View();
    }

    // GET: Privacy policy page
    public IActionResult Privacy()
    {
        return View();
    }

    // GET: Pricing page
    public IActionResult Pricing()
    {
        return View();
    }

    // GET: Error page (with request ID for debugging)
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
