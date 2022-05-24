namespace Vendista.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Error(string id)
    {
        return id switch
        {
            "404" => View("Error404"),
            _ => Content($"Status --- {id}"),
        };
    }
}