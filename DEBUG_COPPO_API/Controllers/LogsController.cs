using Microsoft.AspNetCore.Mvc;

namespace DEBUG_COPPO_API.Controllers;

public class LogsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}