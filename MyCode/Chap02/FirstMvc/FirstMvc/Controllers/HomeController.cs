using FirstMvc.Infrastructure;
using FirstMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FirstMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }

        [HttpGet]
        public IActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RsvpForm(GuestResponseModel model)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(model);
                return View("Thanks", model);
            }
            else
            {
                return View();
            }
        }

        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }
    }
}