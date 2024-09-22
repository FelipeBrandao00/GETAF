using Microsoft.AspNetCore.Mvc;

namespace GETAF.Controllers
{
    public class EsqueciSenhaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReceberCodigo(string Email)
        {
            return null;
        }
    }
}
