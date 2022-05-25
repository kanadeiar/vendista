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
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Vendista(VendistaWebModel model)
    {
        var types = await _service.GetCommandTypes();
        model.CommandTypes = types;
        if (model.SelectedType != 0)
        {
            var selected = types.First(x => x.Id == model.SelectedType);
            model.Parameter1Name = selected.Parameter_Name1;
            model.Parameter1 = selected.Parameter_Default_Value1;
            model.Parameter2Name = selected.Parameter_Name2;
            model.Parameter2 = selected.Parameter_Default_Value2;
            model.Parameter3Name = selected.Parameter_Name3;
            model.Parameter3 = selected.Parameter_Default_Value3;
        }
        return View(model);
    }

    [HttpPost]
    public IActionResult SendCommand(VendistaWebModel model)
    {
        Console.WriteLine("command sended");

        return RedirectToAction("Vendista", "Home");
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