using Microsoft.AspNetCore.Mvc;
using System;

namespace ViewDemo01.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Hello";

            return View(DateTime.Now);
        }

        public ViewResult Result() => View((object)"Hello World");

        public RedirectResult Redirect() => Redirect("/Example/Index");

        public RedirectResult RedirectPermanent() => RedirectPermanent("/Example/Index");

        public RedirectToRouteResult RedirectToRoute() =>
            RedirectToRoute(new { controller = "Example", action = "Index" });

        public RedirectToActionResult RedirectToActionDemo() => RedirectToAction("Index", "Home");

        public JsonResult JsonDemo() => Json(new[] { "Alice", "Bob", "Joe" });

        public ContentResult ContentDemo()
            => Content("[\"Alice\",\"Bob\",\"Joe\"]", "application/json");

        public ObjectResult ObjectDemo() => Ok(new string[] { "Alice", "Bob", "Joe" });
    }
}