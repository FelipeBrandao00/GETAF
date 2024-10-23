using Microsoft.AspNetCore.Mvc;

namespace GETAF.Controllers
{
    public class RankingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ranking()
        {
            return View();
        }

    }
}
