using Microsoft.AspNetCore.Mvc;

namespace BilletDeConcert.Controllers
{
    public class Artiste_ConcertsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
