using MeeHealth.MHDumper.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace ViewDemo01.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _logger.LogDebug("HomeController ctor");
        }

        public IActionResult Index()
        {
            _logger.LogDebug("HomeController.Index");
            return View("SimpleForm");
        }

        public ViewResult Headers()
        {
            Dictionary<string, string> model = Request.Headers.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.First());
            _logger.LogDebug(model.DumpToString());
            return View("DictionaryResult", model);
        }

        public ViewResult SimpleForm() => View("SimpleForm");

        //public ViewResult ReceiveForm()
        //{
        //    Microsoft.Extensions.Primitives.StringValues name = Request.Form["name"];
        //    Microsoft.Extensions.Primitives.StringValues city = Request.Form["city"];
        //    return View("Result", $"{name} lives in {city}");
        //}
        [HttpPost]
        public RedirectToActionResult ReceiveForm(string name, string city)
        {
            TempData["name"] = name;
            TempData["city"] = city;
            return RedirectToAction("Data");
        }

        public ViewResult Data()
        {
            string name = TempData["name"] as string;
            string city = TempData["city"] as string;
            return View("Result", $"{name} lives in {city}");
        }
    }
}