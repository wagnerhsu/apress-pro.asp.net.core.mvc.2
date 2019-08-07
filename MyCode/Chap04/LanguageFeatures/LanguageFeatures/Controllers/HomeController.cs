using LanguageFeatures.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> PageLength()
        {
            ViewBag.PageLength = await MyAsyncMethods.GetPageLength();
            return View();
        }
    }
}