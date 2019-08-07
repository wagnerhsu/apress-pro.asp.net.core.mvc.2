using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ViewDemo01.Controllers
{
    public class HttpResultController : Controller
    {
        public StatusCodeResult StatusCodeDemo()
        {
            return StatusCode(StatusCodes.Status404NotFound);
        }
        public StatusCodeResult NotFoundDemo() => NotFound();
    }
}