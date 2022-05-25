using Vendista.WebModels;

namespace Vendista.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IVendistaService _service;

    public HomeController(ILogger<HomeController> logger, IVendistaService service)
    {
        _logger = logger;
        _service = service;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Vendista()
    {
        var types = await _service.GetCommandTypes();
        var model = new VendistaWebModel
        {
            TerminalId = 129,
            CommandTypes = types,
            Parameter1 = 10_000,
        };
        return View(model);
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