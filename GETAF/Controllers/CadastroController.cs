using GETAF.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GETAF.Controllers
{
    public class CadastroController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public JsonResult Cadastrar([FromBody] CadastroModel cadastro)
        {
            var retorno = cadastro.Cadastrar();
            return Json(retorno);


        }
    }
}
