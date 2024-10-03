using Microsoft.AspNetCore.Mvc;

namespace GETAF.Models.ViewModel
{
    public class CodigoSenhaModel : Controller
    {
        public IActionResult ReceberCodigo()
        {
            return View();
        }
    }
}
