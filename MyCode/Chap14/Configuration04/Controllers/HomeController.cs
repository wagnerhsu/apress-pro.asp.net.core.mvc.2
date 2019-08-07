using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    UptimeService uptime;
    public HomeController(UptimeService up)
    {
        uptime = up;
    }
    public IActionResult Index()
    {
        return View(new Dictionary<string, string>
        {
            ["Message"] = "This is the Index action",
            ["Uptime"] = $"{uptime.Uptime}ms"
        });
    }
}
