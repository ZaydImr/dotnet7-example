using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("/")]
    [Controller]
    public class HomeController : Controller
    {
        // GET: HomeController
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

    }
}
